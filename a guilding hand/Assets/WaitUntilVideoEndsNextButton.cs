using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaitUntilVideoEndsNextButton : MonoBehaviour
{
    public float delay = 5f;

    public Button nextButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextButton = GetComponent<Button>();
        nextButton.enabled = false;
        StartCoroutine(WaitFortheVideoToFinish(2f));   
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitFortheVideoToFinish(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        nextButton.enabled = true;
    }
}
