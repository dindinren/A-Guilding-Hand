using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CanvasFade : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;

    public bool fadeIn;
    public bool fadeOut;
    public float fadeDuration;    

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
        if (fadeIn)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime;
                if(canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
        if (fadeOut)
        {
            if(canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= Time.deltaTime;
                if(canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }

    }

    public void FadeIn()
    {
        canvasGroup.alpha = 0;
        fadeIn = true;
    }
    public void FadeOut()
    {
        canvasGroup.alpha = 1f;
        fadeOut = true;
    }
}
