using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    //Health system where if you get all 3 of the cross to red, it means the player is terminated and lost
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;

    public GameObject gameOverScreen;
   

    int score = 0;
    public int healthscore = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }

    //this one very self explantory right??
    public void AddPoints()
    {
        score += 1;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void MinusPoints()
    {
        if (score <= 0)
        {
            score = 0;
        }
        else
        {
            score -= 1;
        }

        healthscore++;
        Debug.Log("healthscore is : "+healthscore);
        //change the tick to red to indicate that the player did wrong
        switch (healthscore)
        {
            //strike 1
            case 1:
                health1.GetComponent<Image>().color = Color.white;
                health2.GetComponent<Image>().color = Color.black;
                health3.GetComponent<Image>().color = Color.black;
                break;
            //strike 2
            case 2:
                health1.GetComponent<Image>().color = Color.white;
                health2.GetComponent<Image>().color = Color.white;
                health3.GetComponent<Image>().color = Color.black;
                break;
            //strike 3
            case 3:
                health1.GetComponent<Image>().color = Color.white;
                health2.GetComponent<Image>().color = Color.white;
                health3.GetComponent<Image>().color = Color.white;

                gameOverScreen.SetActive(true);

                break;
            default:
                //set the health to black to indicate you have no strikes
                health1.GetComponent<Image>().color = Color.black;
                health2.GetComponent<Image>().color = Color.black;
                health3.GetComponent<Image>().color = Color.black;
                break;
        }

        scoreText.text = "SCORE: " +score.ToString();
    }
}
