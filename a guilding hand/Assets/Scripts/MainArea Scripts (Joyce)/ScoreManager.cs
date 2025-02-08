using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    int score = 0;

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
        if (score <= 0) score = 0;
        else score -= 1;

        scoreText.text = "SCORE: " +score.ToString();
    }
}
