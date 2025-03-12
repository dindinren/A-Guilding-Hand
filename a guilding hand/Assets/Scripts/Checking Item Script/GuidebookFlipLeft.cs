using UnityEngine;

public class GuidebookFlipLeft : MonoBehaviour
{
    public GuidebookpHManager guidebookpHManager;
    public PauseMenu pauseMenu;
    public GameObject flipleft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Update()
    {
        if (pauseMenu.isPause == true)
        {
            flipleft.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            flipleft.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    // Update is called once per frame
    private void OnMouseDown()
    {
        guidebookpHManager.Backward();
    }
}
