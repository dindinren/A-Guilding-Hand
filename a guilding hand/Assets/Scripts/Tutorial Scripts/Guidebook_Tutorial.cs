using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Guidebook_Tutorial : MonoBehaviour
{
    public GameObject guidebook;

    public Button guidebookButton;

    private Animator anim;

    public  bool moveToSecondPhase = false;
    public GameObject dialogue2;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

        //guidebook.GetComponent<Image>().enabled = false;
        guidebook.SetActive(false);

        //anim.Play("Guidebook_Tutorial-idle");

        guidebookButton.onClick.AddListener(GuidebookAppear);
        guidebookButton.onClick.AddListener(GuidebookAppear);

        if(moveToSecondPhase == false)
        {
            dialogue2.SetActive(false);
  
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(moveToSecondPhase == true)
        {
            dialogue2.SetActive(true);
        }
        
    }



    public void GuidebookAppear()
    {
        //guidebook.GetComponent<Image>().enabled = true;
        guidebook.SetActive(true);
        anim.Play("Guidebook_Tutorial-OnEnter");
    }


    public void GuidebookGoByeBye()
    {
        moveToSecondPhase = true;

        StartCoroutine(GuidebookGoByeByeTiming(1f));
    }

    IEnumerator GuidebookGoByeByeTiming(float delay)
    {
        anim.Play("Guidebook_Tutorial-OnExit");

        yield return new WaitForSeconds(delay);

        //guidebook.GetComponent<Image>().enabled = false;
        guidebook.SetActive(false);
    }

}
