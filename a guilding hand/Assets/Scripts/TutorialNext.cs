using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class TutorialNext : MonoBehaviour
{
    public Button skipButton;
    public Button nextButton;
    public Button prevButton;

    public int buttonCount = 1;

    public GameObject Pic1;
    public GameObject Pic2;
    public GameObject Pic3;
    public GameObject Pic4;
    public GameObject Pic5;
    public GameObject Pic6;
    public GameObject Pic7;
    public GameObject Pic8;
    public GameObject Pic9;
    private GameObject Pic10;



    public void Start()
    {
        tutorialPicture();
    }

    public void Skip()
    {
        SceneManager.LoadScene("MainArea");
    }


    //next tutorial picture
    //i apologise in advance for the code ahead 
    public void tutorialPicture()
    {
        //now before you ask wtf you need all this Pic setactive to false
        //well if i dun do this shit it will pile up and it will just stay on the screen forever 
        //i think it would be better with object pooling? or not i may be pullling my ass out for a better optimisation
        switch (buttonCount)
        {
            case 2:
                //the back button will show
                prevButton.GetComponent<Image>().enabled = true;
                prevButton.GetComponent<Button>().enabled = true;
                prevButton.GetComponentInChildren<TMP_Text>().enabled = true;

                Pic2.SetActive(true);
                Pic1.SetActive(false); Pic3.SetActive(false); Pic4.SetActive(false); Pic5.SetActive(false); Pic6.SetActive(false); Pic7.SetActive(false); Pic8.SetActive(false); Pic9.SetActive(false);
                break;
            case 3:
                Pic3.SetActive(true);
                Pic2.SetActive(false); Pic4.SetActive(false); Pic5.SetActive(false); Pic6.SetActive(false); Pic7.SetActive(false); Pic8.SetActive(false); Pic9.SetActive(false);
                break;
            case 4:
                Pic4.SetActive(true);
                Pic3.SetActive(false); Pic5.SetActive(false); Pic6.SetActive(false); Pic7.SetActive(false); Pic8.SetActive(false); Pic9.SetActive(false);
                break;
            case 5:
                Pic5.SetActive(true);
                Pic4.SetActive(false); Pic6.SetActive(false); Pic7.SetActive(false); Pic8.SetActive(false); Pic9.SetActive(false);
                break;
            case 6:
                Pic6.SetActive(true);
                Pic5.SetActive(false); Pic7.SetActive(false); Pic8.SetActive(false); Pic9.SetActive(false);
                break;
            case 7:
                Pic7.SetActive(true);
                Pic6.SetActive(false); Pic8.SetActive(false); Pic9.SetActive(false);
                break;
            case 8:
                Pic8.SetActive(true);
                Pic7.SetActive(false); Pic9.SetActive(false);
                break;
            case 9:
                Pic9.SetActive(true);
                Pic8.SetActive(false); 
                break;
            case 10:
                Skip();
                break;
            default:
                //the back button will not show on the first page
                prevButton.GetComponent<Image>().enabled = false;
                prevButton.GetComponent<Button>().enabled = false;
                prevButton.GetComponentInChildren<TMP_Text>().enabled = false;


                Pic1.SetActive(true);
                Pic2.SetActive(false);
                Pic3.SetActive(false);
                Pic4.SetActive(false);
                Pic5.SetActive(false);
                Pic6.SetActive(false);
                Pic7.SetActive(false);
                Pic8.SetActive(false);
                Pic9.SetActive(false);
                break;
        }
    }
    //move to the next picture
    public void nextTutorialPicture()
    {
        buttonCount+=1;
        tutorialPicture();

        Debug.Log("The button count is: " +buttonCount);

    }
    //go back a page
    public void prevTutorialPicture()
    {
        buttonCount--;


        if (buttonCount == 0 )
        {
            buttonCount = 1;
        }

        Debug.Log("The button count is: " + buttonCount);

        tutorialPicture();
    }
}

