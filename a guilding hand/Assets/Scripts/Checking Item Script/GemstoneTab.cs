using UnityEngine;

public class GemstoneTab : MonoBehaviour
{
    public GuidebookpHManager GuidebookpHManager;
    public PauseMenu pauseMenu;
    public GameObject gemstoneTab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
        if (pauseMenu.isPause == true)
        {
            gemstoneTab.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            gemstoneTab.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnMouseDown()
    {

        GuidebookpHManager.SkipToGemstone();
    }
}
