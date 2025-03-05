using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GuidebookpHManager : MonoBehaviour
{


    public List <Sprite> spriteList;
    public SpriteRenderer guidebook;
    private int currentindex = 0;
    public GameObject arrowForward;
    public GameObject arrowBackward;

    void Start()
    {
        guidebook.sprite = spriteList[0];
        arrowBackward.SetActive(false);
    }
    public void Forward()
    {
        Debug.Log("forward");
        currentindex++;
       
        
        if (currentindex == spriteList.Count - 1)
        {
          arrowForward.SetActive(false);
        }
        else if (currentindex >= spriteList.Count - 1)
        {
            currentindex--;
        }
        else
        {
            arrowBackward.SetActive(true);
        }
        
        guidebook.sprite = spriteList[currentindex];

    }

    public void Backward()
    {
        Debug.Log("backward");
        currentindex--;

     if (currentindex == 0)
     {
       arrowBackward.SetActive(false);
     }
     else if (currentindex < 0)
        {
            currentindex++;
        }
     else
     {
       arrowForward.SetActive(true);
     }
       
        guidebook.sprite = spriteList[currentindex];
    }

    public void SkipToInstructions()
    {
        Debug.Log("Skipped to instructions page");
        currentindex = 0;
        guidebook.sprite = spriteList[currentindex];
        arrowForward.SetActive(true);
        arrowBackward.SetActive(false);
    }

    public void SkipToGemstone()
    {
        Debug.Log("Skipped to gemstone page");
        currentindex = 1;
        guidebook.sprite = spriteList[currentindex];
        arrowForward.SetActive(true);
        arrowBackward.SetActive(true);
    }

    public void SkipToMonsters()
    {
        Debug.Log("Skipped to monsters page");
        currentindex = 2;
        guidebook.sprite = spriteList[currentindex];
        arrowForward.SetActive(true);
        arrowBackward.SetActive(true);
    }

}
