using System.Collections;
using TMPro;
using UnityEngine;



public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject gameEnd;
    public GameObject scoreText;

    public Animator anim;

    public float remainingTime;

    private bool go = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

        scoreText.SetActive(true);

        gameEnd.SetActive(false); //plays the lost screeen

        timerText.enabled = true;

        StartCoroutine(WaitforaWhileThenGo(1f));

    }

    // Update is called once per frame
    void Update()
    {
        if(go == true)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;


                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);

                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                float stopTime = remainingTime;

                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }


            //make sure the timer does not become a negative number
            if (remainingTime < 0)
            {
                remainingTime = 0;
                timerText.text = "0:00";
            }



            if (remainingTime == 0)
            {
                // will pop up a screen to say your time is up
                
                //stops everything in the scene from moving
                Time.timeScale = 0f;


                gameEnd.SetActive(true);
                anim.Play("GameFinish");


                timerText.enabled = false;
                scoreText.SetActive(false);

            }
        }


    }

    IEnumerator WaitforaWhileThenGo(float delay)
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        yield return new WaitForSeconds(delay);

        go = true;

    }

}
