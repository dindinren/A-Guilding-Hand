using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public GameObject player;

    private Animator anim2;
    private Animator anim;

    public GameObject textBox;

    public Guidebook_Tutorial guidebook_tutorial;
    public Dialogue dialogue;

    public CanvasFade fade;

    bool changeAnimation = false;


    public GameObject highlight1;
    public GameObject highlight2;
    public GameObject highlight3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highlight1.SetActive(false);
        highlight2.SetActive(false);
        highlight3.SetActive(false);

        anim2 = textBox.GetComponent<Animator>();
        anim = player.GetComponent<Animator>();

        StartCoroutine(WaitandThenAnimationPlays(2f));
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.index == 2) //tutorial on the Player healthpoints
        {
            changeAnimation = true;

            anim2.Play("TextBox_Tutorial-Move1");
            anim.Play("PlayerTutorial_Move1");

            highlight1.SetActive(true); //turn the highlight on for the player hp
        }


        if (dialogue.index == 5) //tutorial on the Score and Win conditions
        {
            highlight1.SetActive(false); //turn the highlight off for player hp;

            anim2.Play("TextBox_Tutorial-Move2");
            anim.Play("PlayerTutorial_Move2");
            highlight2.SetActive(true);
        }


        if(dialogue.index == 7) //tutorial on the Timer
        {
            highlight2.SetActive(false); //turn highlight off for the score + Win Tutorial

            highlight3.SetActive(true); //turn the highlight on for the Timer tutorial

        }



        if (dialogue.index == 12)
        {
            fade.nextScene = true;
        }


        if (guidebook_tutorial.moveToSecondPhase == true)
        {
            if (changeAnimation == false)
            {
                anim.Play("PlayerTutorial_Idle");
            }
        }
    }

    IEnumerator WaitandThenAnimationPlays(float delay = 3f)
    {
        yield return new WaitForSeconds(delay);

        anim.Play("PlayerTutorial_OnEnter");
        Debug.Log("it pops up");
    }

}
