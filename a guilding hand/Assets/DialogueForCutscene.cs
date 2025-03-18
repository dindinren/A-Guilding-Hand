using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueForCutscene : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string line;
    public float textSpeed;

    private int index;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = "";
        StartCoroutine((TypeLine()));
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (textComponent.text == lines[index])
        //    {
        //        NextLine();
        //        Debug.Log("to the next line");
        //    }
        //    else
        //    {
        //        StopAllCoroutines();
        //        textComponent.text = lines[index]; //get the current line and fills it out 

        //    }
        //}
    }


    //public void StartDialogue()
    //{
    //}


    //void NextLine()
    //{
    //    if (index < lines.Length - 1)
    //    {
    //        index++;
    //        textComponent.text = string.Empty;
    //        StartCoroutine(TypeLine());
    //    }
    //    else
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}

    IEnumerator TypeLine()
    {
        foreach (char c in line.ToCharArray())
        {
            yield return new WaitForSeconds(textSpeed);

            textComponent.text += c;
        }
    }
}
