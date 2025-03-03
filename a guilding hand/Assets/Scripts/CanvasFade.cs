using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasFade : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;

    public bool fadeIn;
    public bool fadeOut;
    //public float fadeDuration;


    public bool nextScene = false;

    public string sceneName;

    private void Start()
    {
        if(fadeOut == true)
        {
            FadeOut();
        }
        if(fadeIn == true)
        {
            FadeIn();
        }
    }

    private void Update()
    {
        if (nextScene == false)
        {
            if(sceneName == "MainArea")
            {
                StartCoroutine(FadeInTimer(0.2f));
                Debug.Log("time for mainArea");
            }
            else
            {
                StartCoroutine(FadeInTimer(0.5f));
                Debug.Log("time for everywhwere else");
            }
        }
        if (nextScene == true)
        {
            fadeOut = true;
            StartCoroutine(FadeOutandThenLoadNextScene(1f));
        }
    }

    IEnumerator FadeOutandThenLoadNextScene(float delay)
    {
        if (fadeOut)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= Time.deltaTime;

                if (canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);

    }

    IEnumerator FadeInTimer(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (fadeIn)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

    }

    public void FadeIn()
    {
        canvasGroup.alpha = 0;
        fadeIn = true;
        nextScene = false;
    }
    public void FadeOut()
    {
        canvasGroup.alpha = 1f;
        fadeOut = true;
        nextScene = true;
    }
}
