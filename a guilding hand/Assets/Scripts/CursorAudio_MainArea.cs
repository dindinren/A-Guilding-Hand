using UnityEngine;

public class CursorAudio_MainArea : MonoBehaviour
{
    AudioManager_MainArea audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_MainArea>();
        if (audioManager == null)
        {
            Debug.LogError("CursorAudio_MainArea Awake: AudioManager_MainArea not found! Make sure it's in the scene and tagged 'AudioManager'.", this);
        }
    }

    public void OnMouseDown()
    {
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.ClickSFX);
        }
        else
        {
            Debug.LogWarning("CursorAudio_MainArea: AudioManager is null, cannot play ClickSFX.", this);
        }
    }

    public void OnMouseEnter()
    {
        if (audioManager != null)
        {
            // CHANGED: Call the new method for random general hover SFX
            audioManager.PlayGeneralHoverSFX();
            Debug.Log("Playing general hover sound from CursorAudio_MainArea.");
        }
        else
        {
            Debug.LogWarning("CursorAudio_MainArea: AudioManager is null, cannot play GeneralHoverSFX.", this);
        }
    }

    void Start()
    {
        // No Start logic needed here unless you add it
    }

    void Update()
    {
        // No Update logic needed here unless you add it
    }
}
