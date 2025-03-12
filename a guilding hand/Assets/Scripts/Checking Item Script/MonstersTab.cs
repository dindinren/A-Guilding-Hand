using UnityEngine;

public class MonstersTab : MonoBehaviour
{
    public GuidebookpHManager GuidebookpHManager;
    public PauseMenu pauseMenu;
    public GameObject monstersTab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
        if (pauseMenu.isPause == true)
        {
            monstersTab.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            monstersTab.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    // Update is called once per frame
    private void OnMouseDown()
    {

        GuidebookpHManager.SkipToMonsters();
    }
}
