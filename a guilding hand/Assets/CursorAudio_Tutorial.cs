using UnityEngine;

public class CursorAudio_Tutorial : MonoBehaviour
{
    AudioManager_Tutorial audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_Tutorial>();
    }

    public void OnMouseDown()
    {
        audioManager.PlaySFX(audioManager.ClickSFX);
    }
    public void OnMouseEnter()
    {
        audioManager.PlaySFX(audioManager.HoverSFX);
    }

}
