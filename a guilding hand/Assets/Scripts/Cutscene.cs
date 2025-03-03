using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;

    public bool fadeIn;
    public bool fadeOut;
    //public float fadeDuration;

    public Button play;

    public bool nextScene = false;

    private string sceneName;



    public void TotheNextScene()
    {
        sceneName = "tutorial";
        fadeOut = true;
        StartCoroutine(FadeOutandThenLoadNextScene());
    }

    private void Start()
    {
        play.onClick.AddListener(CheckifCanGoNextScene);
    }

    public void CheckifCanGoNextScene()
    {
        fadeOut = true;
    }

    private void Update()
    {
        if (fadeOut == true)
        {
            TotheNextScene();
        }
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
    public void FadeOut()
    {
        canvasGroup.alpha = 1f;
        fadeOut = true;
    }





    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
