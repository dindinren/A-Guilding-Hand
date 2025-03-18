using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guidebook_Main : MonoBehaviour
{
    public GameObject guidebook;
    public List<GameObject> guidebookList;

    private int currentindex = 0;

    public GameObject arrowForward;
    public GameObject arrowBackward;


    public Button guidebookButton;


    private Animator anim;


    AudioManager_MainArea audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_MainArea>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

        guidebook.SetActive(false);

        arrowForward.SetActive(true);
        arrowBackward.SetActive(false);


        guidebookButton.onClick.AddListener(GuidebookAppear);

    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }


    public void Forward()
    {
        Debug.Log("go foward");
        currentindex++;
        GuidebookPages();

        audioManager.PlaySFX(audioManager.GuidebookFlipSFX);
    }

    public void Backward()
    {
        currentindex--;
        GuidebookPages();

        audioManager.PlaySFX(audioManager.GuidebookFlipSFX);
    }


    public void GuidebookAppear()
    {
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
