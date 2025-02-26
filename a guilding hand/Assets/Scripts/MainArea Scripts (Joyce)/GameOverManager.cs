using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TryAgain()
    {
        SceneManager.LoadScene("MainArea");
    }

    public void ReturntoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
