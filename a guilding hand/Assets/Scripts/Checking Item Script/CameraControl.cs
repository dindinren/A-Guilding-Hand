using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI; // Make sure this is included if you are using UI elements for buttons

public class CameraControl : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject newCameraLocation;
    public GameObject guidebook;
    private Vector3 mainlocation;

    // ***** NEW: Public AudioClips for specific hover sounds directly on this script *****
    [Header("Hover SFX")]
    [Tooltip("Assign the SFX to play when the mouse hovers over the Magnifying Glass button.")]
    public AudioClip MagnifyingGlassHoverSFX;
    [Tooltip("Assign the SFX to play when the mouse hovers over the Pipette button.")]
    public AudioClip PipetteHoverSFX;
    public AudioClip BackHoverSFX;
    // **********************************************************************************

    // ***** NEW: Cooldown variables for hover SFX *****
    private float lastHoverSFXTime;
    private const float hoverSFXCooldown = 2.0f; // 1 second cooldown
    // *************************************************

    // We no longer need to manually find the AudioManager instance in Awake/Start
    // as we'll use its static Instance property directly.
    // private AudioManager_MainArea audioManager; // REMOVED

    void Start()
    {
        // Ensure mainCamera reference is set, typically this is Camera.main
        mainCamera = Camera.main.gameObject;

        // If newCameraLocation isn't set in the Inspector, try to find it by tag
        if (newCameraLocation == null)
        {
            newCameraLocation = GameObject.FindGameObjectWithTag("InitialItemCam");
            if (newCameraLocation == null)
            {
                Debug.LogWarning("CameraControl: 'InitialItemCam' GameObject not found. Please assign 'New Camera Location' in the Inspector or ensure the tag is correct.", this);
            }
        }

        // Store the main camera's initial position
        mainlocation = mainCamera.transform.position;

        // Initialize the last hover time to allow immediate playback on first hover
        lastHoverSFXTime = -hoverSFXCooldown;
    }

    void Update()
    {
        // This logic controls the guidebook's visibility based on camera position
        if (mainCamera != null && guidebook != null)
        {
            if (mainCamera.transform.position != mainlocation)
            {
                guidebook.gameObject.SetActive(false);
            }
            else
            {
                guidebook.gameObject.SetActive(true);
            }
        }
    }

    // This method is called when the mouse button is pressed down over this object's collider.
    void OnMouseDown()
    {
        // Ensure the game is not paused (assuming PauseMenu.instance is correctly set up)
        if (PauseMenu.instance != null && !PauseMenu.instance.isPause)
        {
            // Check if a new camera location is assigned before attempting to move
            if (newCameraLocation != null)
            {
                Debug.Log($"Moving camera to new location defined by: {newCameraLocation.name}");

                // Set the guidebook inactive immediately when the button is clicked
                if (guidebook != null)
                {
                    guidebook.gameObject.SetActive(false);
                }

                // Move the main camera to the new location's X and Y, keeping its current Z
                Vector3 oldPos = mainCamera.transform.position;
                mainCamera.transform.position = new Vector3(newCameraLocation.transform.position.x, newCameraLocation.transform.position.y, oldPos.z);
            }
            else
            {
                Debug.LogWarning("CameraControl: 'New Camera Location' (InitialItemCam) is not assigned or found. Camera will not move.", this);
            }

            // Play the general ClickSFX through the AudioManager singleton
            if (AudioManager_MainArea.Instance != null)
            {
                AudioManager_MainArea.Instance.PlaySFX(AudioManager_MainArea.Instance.ClickSFX);
            }
            else
            {
                Debug.LogWarning("CameraControl: AudioManager_MainArea instance not found. Cannot play Click SFX.", this);
            }
        }
    }

    // ***** MODIFIED: Mouse Hover Detection - OnMouseEnter with Cooldown *****
    // This method is called when the mouse cursor enters the object's 2D collider.
    void OnMouseEnter()
    {
        // Only play SFX if the game is not paused AND the cooldown has passed
        if (PauseMenu.instance != null && !PauseMenu.instance.isPause && Time.time >= lastHoverSFXTime + hoverSFXCooldown)
        {
            if (AudioManager_MainArea.Instance != null)
            {
                AudioClip clipToPlay = null;

                // Check the tag of *this* GameObject (the button) to determine which SFX to play.
                if (gameObject.CompareTag("Magnifying glass button"))
                {
                    clipToPlay = MagnifyingGlassHoverSFX;
                }
                else if (gameObject.CompareTag("Pipette button"))
                {
                    clipToPlay = PipetteHoverSFX;
                }
                // You can add more else if statements for other button tags and their hover SFX

                if (clipToPlay != null)
                {
                    AudioManager_MainArea.Instance.PlaySFX(clipToPlay);
                    lastHoverSFXTime = Time.time; // Update the last played time
                    Debug.Log($"Playing {gameObject.tag} Hover SFX");
                }
                else
                {
                    // If a button tag is recognized but no clip is assigned for it
                    Debug.LogWarning($"No hover SFX assigned in CameraControl for the '{gameObject.tag}' button. Please assign an AudioClip in the Inspector.", this);
                }
            }
            else
            {
                Debug.LogWarning("CameraControl: AudioManager_MainArea instance not found. Cannot play hover SFX.", this);
            }
        }
    }

    // This method is called when the mouse cursor exits the object's 2D collider.
    // For one-shot hover sounds, you typically don't need to do anything here.
    void OnMouseExit()
    {
        // If you had a looping hover sound, you would stop it here.
    }
}