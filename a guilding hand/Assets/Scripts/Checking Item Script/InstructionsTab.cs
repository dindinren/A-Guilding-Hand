using UnityEngine;

public class InstructionsTab : MonoBehaviour
{
    public GuidebookpHManager GuidebookpHManager;
    public PauseMenu pauseMenu;
    public GameObject instructionsTab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
        if (pauseMenu.isPause == true)
        {
            instructionsTab.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            instructionsTab.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        GuidebookpHManager.SkipToInstructions();
    }
}
