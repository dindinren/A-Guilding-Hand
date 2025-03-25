using UnityEngine;

public class CursorAudio_MainArea : MonoBehaviour
{
    AudioManager_MainArea audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_MainArea>();
    }

    public void OnMouseDown()
    {
        audioManager.PlaySFX(audioManager.ClickSFX);
    }
    public void OnMouseEnter()
    {
        audioManager.PlaySFX(audioManager.HoverSFX);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
