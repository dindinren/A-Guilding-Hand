using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Guidebook_Main : MonoBehaviour
{
    public GameObject guidebook;

    public Button guidebookButton;

    private Animator anim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

        guidebook.SetActive(false);

        guidebookButton.onClick.AddListener(GuidebookAppear);
        guidebookButton.onClick.AddListener(GuidebookAppear);


    }

    // Update is called once per frame
    void Update()
    {
    }



    public void GuidebookAppear()
    {
        //guidebook.GetComponent<Image>().enabled = true;
        guidebook.SetActive(true);
        anim.Play("Guidebook_Tutorial-OnEnter");
    }


    public void GuidebookGoByeBye()
    {
        StartCoroutine(GuidebookGoByeByeTiming(1f));
    }

    IEnumerator GuidebookGoByeByeTiming(float delay)
    {
        anim.Play("Guidebook_Tutorial-OnExit");

        yield return new WaitForSeconds(delay);

        guidebook.SetActive(false);

    }
}
