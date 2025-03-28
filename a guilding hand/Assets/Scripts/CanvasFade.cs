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
            StartCoroutine(FadeInTimer(0.5f));
        }
        if (nextScene == true)
        {
            fadeOut = true;
            StartCoroutine(FadeOutandThenLoadNextScene(1f));
        }
    }
    public void ToCredits()
    {
        sceneName = "Credits";
        FadeOut();
        StartCoroutine(FadeOutandThenLoadNextScene());
    }


    IEnumerator FadeOutandThenLoadNextScene(float delay = 1f)
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
