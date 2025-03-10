using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPause = false;

    public Animator anim;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        isPause = true;
        Time.timeScale = 0f;

        anim.Play("PauseMenu_OnEnter");
    }

    public void Resume()
    {
        anim.Play("PauseMenu_OnExit");
        Debug.Log("DOES THE ANIMATION PLAYS");

        pauseMenu.SetActive(false);
        isPause = false;
        Time.timeScale = 1f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
