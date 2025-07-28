using UnityEngine;

public class GuidebookHoverSound : MonoBehaviour
{
    private AudioManager_MainArea audioManager;

    void Awake()
    {
        // Find the AudioManager in the scene
        // Make sure your AudioManager_MainArea GameObject is tagged "AudioManager"
        GameObject audioManagerGO = GameObject.FindGameObjectWithTag("AudioManager");
        if (audioManagerGO != null)
        {
            audioManager = audioManagerGO.GetComponent<AudioManager_MainArea>();
            if (audioManager == null)
            {
                Debug.LogError("GuidebookHoverSound: AudioManager_MainArea script not found on GameObject tagged 'AudioManager'.", this);
            }
        }
        else
        {
            Debug.LogError("GuidebookHoverSound: GameObject tagged 'AudioManager' not found in scene.", this);
        }
    }

    // Called when the mouse pointer enters the collider
    void OnMouseEnter()
    {
        if (audioManager != null)
        {
            audioManager.PlayGuidebookHoverSFX();
            Debug.Log("Playing Guidebook Hover SFX.");
        }
    }

    // You might also want to stop a sound or do something when the mouse leaves
    // void OnMouseExit()
    // {
    //    // audioManager.StopGuidebookHoverSFX(); // If you want a specific stop method
    // }
}