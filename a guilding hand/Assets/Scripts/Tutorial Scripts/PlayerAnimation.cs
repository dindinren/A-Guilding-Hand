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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highlight1.SetActive(false);
        highlight2.SetActive(false);

        anim2 = textBox.GetComponent<Animator>();
        anim = player.GetComponent<Animator>();

        StartCoroutine(WaitandThenAnimationPlays(2f));
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.index == 2) //tutorial on the termination
        {
            changeAnimation = true;
            anim2.Play("TextBox_Tutorial-Move1");
            anim.Play("PlayerTutorial_Move1");
            highlight1.SetActive(true);
        }


        if (dialogue.index == 6) //tutorial on the Score and Win conditions
        {
            highlight1.SetActive(false); //turn the highlight off;

            anim2.Play("TextBox_Tutorial-Move2");
            anim.Play("PlayerTutorial_Move2");
            highlight2.SetActive(true);
        }
        if(dialogue.index == 7)
        {
            highlight2.SetActive(false); //turn highlight off
        }


        if (dialogue.index == 8)
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
