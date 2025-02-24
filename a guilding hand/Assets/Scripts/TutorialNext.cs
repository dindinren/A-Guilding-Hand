using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class TutorialNext : MonoBehaviour
{
    public Button skipButton;
    public Button nextButton;

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

    public void Skip()
    {
        SceneManager.LoadScene("MainArea");
        //buttonCount = 0;
    }


    //next tutorial picture
    //sorry if its shit i do not know any other way 
    public void nextTutorialPicture()
    {
        buttonCount+=1;

        Debug.Log("The button count is: " +buttonCount);

        switch (buttonCount)
        {
            case 2:
                Pic2.SetActive(true);
                Pic1.SetActive(false);
                break;
            case 3:
                Pic3.SetActive(true);
                Pic2.SetActive(false);
                break;
            case 4:
                Pic4.SetActive(true);
                Pic3.SetActive(false);
                break;
            case 5:
                Pic5.SetActive(true);
                Pic4.SetActive(false);
                break;
            case 6:
                Pic6.SetActive(true);
                Pic5.SetActive(false);
                break;
            case 7:
                Pic7.SetActive(true);
                Pic6.SetActive(false);
                break;
            case 8:
                Pic8.SetActive(true);
                Pic7.SetActive(false);
                break;
            case 9:
                Pic9.SetActive(true);
                Pic8.SetActive(false);
                break;
            case 10:
                Skip();
                break;
            default:
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
}
