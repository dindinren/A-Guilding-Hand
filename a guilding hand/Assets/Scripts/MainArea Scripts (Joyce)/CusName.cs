using System.Runtime.CompilerServices;
using Unity.IO.Archive;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CusName : MonoBehaviour
{
    public Text nameText;
    public Text nameText2;

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
    public void setText(string setText)
    {
        nameText.text = setText;
        //Debug.Log("x");
    }
    //this is for the second text
    public void setText2(string setText2)
    {
        nameText2.text = setText2;
    }

    //this is to check whether to randomise the names or not
    public void ChanceRandomise()
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

    public void ChooseName()
    {
        //set the text renderer to be shown 
        nameText.gameObject.GetComponent<Text>().enabled = true;
        nameText2.gameObject.GetComponent<Text>().enabled = true;
        Debug.Log("ChooseName Ran");

        //spin the wheel and find whether the names are the same
        ChanceRandomise();

        //not randomise
        if (isNameRandomise == false)
        {
            int index = Random.Range(0, names.Length);

            name1 = names[index];
            name2 = names[index];

            setText(name1);
            setText2(name2);

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

            setText(name1);
            Debug.Log("the name is:" + name1);

            setText2(name2);
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


    }

}
