using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CanvasFade : MonoBehaviour
{
    [SerializeField] CanvasGroup Fade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Fade.alpha = 0f;  
    }

    public void FadeIn()
    {
        Fade.alpha += Time.deltaTime;
    }

    public void FadeOut()
    {
        Fade.alpha -= Time.deltaTime;
    }

    // Update is called once per frame
    public void Update()
    {
        FadeIn();
    }
}
