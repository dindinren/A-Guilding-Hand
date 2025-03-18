using UnityEngine;

public class MonstersTab : MonoBehaviour
{
    public GuidebookpHManager GuidebookpHManager;
    public PauseMenu pauseMenu;
    public GameObject monstersTab;

    //for audio -joyce
    AudioManager_MainArea audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_MainArea>();
    }


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

        //audio sfx - joyce
        audioManager.PlaySFX(audioManager.GuidebookFlipSFX);
    }
}
