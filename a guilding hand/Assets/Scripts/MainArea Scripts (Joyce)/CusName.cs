using System.Runtime.CompilerServices;
using Unity.IO.Archive;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CusName : MonoBehaviour
{
    public TextMeshPro nameText;
    public TextMeshPro nameText2;
    private SpawnManager predeterminedTrueFalse;

    public string[] names = new string[]
    {
        "John","James","Tom","Jamie","Jacklyn"
    };

    public bool isNameRandomise = false;
    public bool areTheNameSame = false;

    string name1;
    string name2;

    
    
    //Spawning the text
    //this is for the first text
    public void setText(TextMeshPro setText)
    {
        nameText = setText;
        //Debug.Log("x");
    }
    //this is for the second text
    public void setText2(TextMeshPro setText2)
    {
        nameText2 = setText2;
    }

    //this is to check whether to randomise the names or not
    public void ChanceRandomise()
    {
        if (predeterminedTrueFalse.StartTrueFalse() == true)
        {
            isNameRandomise = false;
        }
        else
        {
            int chance = Random.Range(0, 5);
            if (chance >= 3)
            {
                Debug.Log("is it randomise?");
                isNameRandomise = true;
            }
            else
            {
                Debug.Log("is it randomise 2 ?");
                isNameRandomise = false;
            }
        }

    }

    public void ChooseName()
    {
        //set the text renderer to be shown 
        //nameText.gameObject.GetComponent<Text>().enabled = true;
        //nameText2.gameObject.GetComponent<Text>().enabled = true;
        Debug.Log("ChooseName Ran");

        //spin the wheel and find whether the names are the same
        ChanceRandomise();

        //not randomise
        if (isNameRandomise == false)
        {
            int index = Random.Range(0, names.Length);

            name1 = names[index];
            name2 = names[index];

            nameText.text = name1;
            nameText2.text = name2;

            areTheNameSame = true;
            Debug.Log("Name Same");
        }
        //can randomise 
        if (isNameRandomise == true)
        {
            Debug.Log("hello???");
            int index = Random.Range(0, names.Length);
            int index2 = Random.Range(0, names.Length);

            while (index == index2)
            {
                index2 = Random.Range(0, names.Length);
            }

            name1 = names[index];
            Debug.Log("index" + index);
            name2 = names[index2];
            Debug.Log("index" + index2);

            nameText.text = name1;
            Debug.Log("the name is:" + name1);

            nameText2.text = name2;
            Debug.Log("the name is: " + name2);

            areTheNameSame = false;
            Debug.Log("Name Not Same");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        nameText.gameObject.SetActive(false);
        nameText2.gameObject.SetActive(false);
        */
        //ChooseName(); (Commented out in ASC)
        predeterminedTrueFalse = Object.FindAnyObjectByType<SpawnManager>();

    }

}
