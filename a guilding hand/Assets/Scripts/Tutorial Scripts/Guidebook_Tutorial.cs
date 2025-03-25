using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guidebook_Tutorial : MonoBehaviour
{
    public GameObject guidebook;
    public List<GameObject> guidebookList;

    private int currentindex = 0;

    public GameObject arrowForward;
    public GameObject arrowBackward;

    public Button guidebookButton;

    private Animator anim;

    public bool moveToSecondPhase = false;

    public GameObject dialogue2;

    AudioManager_Tutorial audioManger;
    private void Awake()
    {
        audioManger = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_Tutorial>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

        GuidebookPages();

        guidebook.SetActive(false);
        guidebookButton.GetComponent<Button>().interactable = false;

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

    public void GuidebookPages()
    {
        if (currentindex == 0)
        {
            guidebookList[0].SetActive(true);
            guidebookList[1].SetActive(false);

            arrowForward.SetActive(true);
            arrowBackward.SetActive(false);
        }
        else if (currentindex == 1)
        {
            guidebookList[0].SetActive(false);
            guidebookList[1].SetActive(true);

            arrowForward.SetActive(false);
            arrowBackward.SetActive(true);

            guidebookButton.GetComponent<Button>().interactable = true;
        }
    }


    public void Forward()
    {
        Debug.Log("go foward");
        currentindex++;
        GuidebookPages();

        audioManger.PlaySFX(audioManger.GuidebookFlipSFX);
    }

    public void Backward()
    {
        currentindex--;
        GuidebookPages();

        audioManger.PlaySFX(audioManger.GuidebookFlipSFX);

    }


    public void GuidebookAppear()
    {
        guidebook.SetActive(true);
        anim.Play("Guidebook_Tutorial-OnEnter");
    }


    public void GuidebookGoByeBye()
    {
        dialogue2.SetActive(true);
        moveToSecondPhase = true;

        StartCoroutine(GuidebookGoByeByeTiming(1f));
    }

    IEnumerator GuidebookGoByeByeTiming(float delay)
    {
        anim.Play("Guidebook_Tutorial-OnExit");

        yield return new WaitForSeconds(delay);

        guidebook.SetActive(false);
    }

}
