using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public int index;

    public Button guidebook;

    private Animator anim;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(WaitandThenAnimationPlay(1.5f));

        textComponent.text = "";
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
                Debug.Log("to the next line");
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index]; //get the current line and fills it out 

            }
        }
    }

    IEnumerator WaitandThenAnimationPlay(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.Play("TextBox_Tutorial-OnEnter");

    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine((TypeLine()));

        guidebook.GetComponent<Button>().interactable = false;

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            guidebook.GetComponent<Button>().interactable = true;

        }
    }
}
