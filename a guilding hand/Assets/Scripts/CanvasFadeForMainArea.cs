using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasFadeForMainArea : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;

    public bool fadeIn;
    public bool fadeOut;

    private bool retry = false;
    private bool menu = false;

    private string sceneName;

    private void Start()
    {
        //fadeIn = true;
        if (fadeOut == true)
        {
            FadeOut();
        }
        if (fadeIn == true)
        {
            FadeIn();
        }
    }

    private void Update()
    {
        if(fadeIn == true)
        {
            StartCoroutine(FadeInTimer(0.5f));
        }

        if(fadeOut == true)
        {
            if(menu == true)
            {
                ToMenu();
            }
            if(retry == true)
            {
                Retry();
            }
        }

    }

    public void Retry()
    {
        fadeOut = true;
        fadeIn = false;
        StartCoroutine(FadeOutandThenRetry(1f));
    }
    IEnumerator FadeOutandThenRetry(float delay)
    {
        retry = true;

        if (fadeOut == true)
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
        Time.timeScale = 1f;
        yield return new WaitForSeconds(delay);

        sceneName = "MainArea";
        SceneManager.LoadScene(sceneName);

    }
    public void ToMenu()
    {
        fadeOut = true;
        fadeIn = false;
        StartCoroutine(FadeOutandThenReturnToMainMenu(1f));
    }
    IEnumerator FadeOutandThenReturnToMainMenu(float delay)
    {
        menu = true;

        if (fadeOut == true)
        {
            if (canvasGroup.alpha <= 1)
            {
                canvasGroup.alpha += Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        Time.timeScale = 1f;
        yield return new WaitForSeconds(delay = 2f);

        sceneName = "Menu";
        SceneManager.LoadScene(sceneName);
    }


    IEnumerator FadeInTimer(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (fadeIn)
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
    }

    public void FadeIn()
    {
        canvasGroup.alpha = 1f;
        fadeIn = true;
    }
    public void FadeOut()
    {
        canvasGroup.alpha = 0f;
        fadeOut = true;
    }
}
