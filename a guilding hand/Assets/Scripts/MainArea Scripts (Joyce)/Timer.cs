using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject gameEnd;
    public GameObject scoreText;

    public float remainingTime;

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
            Time.timeScale = 1f;

            gameEnd.SetActive(true);
            timerText.enabled = false;
            scoreText.SetActive(false);


            //it will stay until the user clicks on it and it will go back to main menu


            StartCoroutine(WaitandthenGotoMenu(1f));

        }

        IEnumerator WaitandthenGotoMenu(float delay)
        {
            yield return new WaitForSeconds(delay);

            //TODO: find a way to fade to black after the screen 
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("Menu");
            }
        }

    }
}
