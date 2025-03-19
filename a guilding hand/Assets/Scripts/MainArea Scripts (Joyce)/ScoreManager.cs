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

    private Animator anim;
    public Animator anim2;

    public GameObject playerNeutral;
    public GameObject playerSad;
    public GameObject playerHappy;


    int score = 0;
    int healthscore = 2; //remember to change to 0
    int playerstate = 0;

    bool playerchange = false;


    AudioManager_MainArea audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_MainArea>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

        gameOverScreen.SetActive(false);

        PlayerState();
        Debug.Log("playerstate: " + playerstate);

        scoreText.text = "SCORE: " + score.ToString();
    }

    private void Update()
    {
        if(playerchange == true)
        {
            PlayerState();
        }
        if(playerchange == false)
        {
            PlayerState();

        }
    }

    public void PlayerState()
    {
        switch (playerstate)
        {
            case 1:
                //Debug.Log("player is sad :(");
                playerSad.SetActive(true);
                playerHappy.SetActive(false);
                playerNeutral.SetActive(false);
                break;
            case 2:
                //Debug.Log("player is happy :D");

                playerSad.SetActive(false);
                playerHappy.SetActive(true);
                playerNeutral.SetActive(false);
                break;
            default:
                //Debug.Log("player is neutral :|");

                playerSad.SetActive(false);
                playerHappy.SetActive(false);
                playerNeutral.SetActive(true);
                break;
        }
    }

    IEnumerator Wait(float dealy)
    {
        yield return new WaitForSeconds(dealy);
        playerstate = 0;
        playerchange = false;
        anim.Play("PlayerIdle");

        Debug.Log("playerstate: " + playerstate);
        Debug.Log("playerstate: " + playerstate);
    }

    //this one very self explantory right??
    public void AddPoints()
    {
        playerchange = true;
        score += 1;
        scoreText.text = "SCORE: " + score.ToString();

        playerstate = 2;
        Debug.Log("playerstate: " + playerstate);


        PlayerState();
        anim.Play("PlayerHappy");
        StartCoroutine(Wait(1f));

        Debug.Log("playerstate: " + playerstate);
    }

    public void MinusPoints()
    {
        playerchange = true;

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

        playerstate = 1;

        PlayerState();
        anim.Play("PlayerSad");

        StartCoroutine(Wait(1f));



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

                Time.timeScale = 0f;

                gameOverScreen.SetActive(true);
                //anim2.Play("GameOver");

                audioManager.GameOver(audioManager.LostBGM);
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
