using UnityEngine;

public class GuidebookFlipRight : MonoBehaviour
{
    public GuidebookpHManager guidebookpHManager;
    public PauseMenu pauseMenu;
    public GameObject flipright;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void Update()
    {
        if (pauseMenu.isPause == true)
        {
            flipright.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            flipright.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    // Update is called once per frame
    private void OnMouseDown()
    {
        guidebookpHManager.Forward();
    }
}
