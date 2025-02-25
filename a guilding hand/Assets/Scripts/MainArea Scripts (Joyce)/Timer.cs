using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject gameEnd;
    public GameObject scoreText;

    

    public float remainingTime;
    float wait;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.SetActive(true);
        gameEnd.SetActive(false);
        timerText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        } 
        if (remainingTime < 0)
        {
            remainingTime = 0;
            timerText.text = "0:00";
        }


        if(remainingTime == 0)
        {
            // will pop up a screen to say your time is up

            //stops everything in the scene from moving
            Time.timeScale = 1f;

            gameEnd.SetActive(true);
            timerText.enabled = false;
            scoreText.SetActive(false);

            //it will stay at the stop ending screen and then return to the main menu
            StartCoroutine(WaitandthenGotoMenu(3f));

        }

    }

    IEnumerator WaitandthenGotoMenu(float delay)
    {
        yield return new WaitForSeconds(delay);

        //TODO: find a way to fade to black after the screen 

        SceneManager.LoadScene("Menu");
        //gameEnd.SetActive(false);

    }
}
