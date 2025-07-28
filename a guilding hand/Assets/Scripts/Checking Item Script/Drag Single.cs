using UnityEngine;
using Unity.VisualScripting; // Keep this if you need it for other parts of your script

public class DragSingle : MonoBehaviour
{
    Vector3 mousePositionOffset;
    Vector3 startPos;

    //for audio -joyce
    AudioManager_MainArea audioManager;
    SpawnManager spawnManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_MainArea>();
        if (audioManager == null)
        {
            Debug.LogError("DragSingle Awake: AudioManager_MainArea not found! Make sure it's in the scene and tagged 'AudioManager'.", this);
        }

        spawnManager = FindObjectOfType<SpawnManager>();
        if (spawnManager == null)
        {
            Debug.LogError("DragSingle Awake: SpawnManager not found in scene! Make sure it exists.", this);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        if (!PauseMenu.instance.isPause)
        {
            audioManager.PlaySFX(audioManager.ClickSFX);
            mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
            startPos = this.transform.position;
            Debug.Log("Magnifying Glass: Mouse Down - Click SFX played.");
        }
    }

    private void OnMouseDrag()
    {
        if (!PauseMenu.instance.isPause)
        {
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
            // Debug.Log("Magnifying Glass: Dragging."); // Only uncomment if you need very verbose logs
        }
    }

    private void OnMouseUp()
    {
        if (!PauseMenu.instance.isPause)
        {
            this.transform.position = startPos;
            Debug.Log("Magnifying Glass: Mouse Up - Returned to start position.");
        }
    }

    // --- MODIFIED: Collision Detection with detailed logs ---
    // Use OnTriggerEnter2D if you are using 2D physics
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Magnifying Glass: OnTriggerEnter2D detected with {other.gameObject.name}.");

        // Check if the collided object has an ItemSpawner component
        ItemSpawner itemSpawner = other.GetComponent<ItemSpawner>();
        if (itemSpawner != null)
        {
            Debug.Log("Magnifying Glass: Collided object has ItemSpawner component.");

            if (spawnManager != null)
            {
                Debug.Log($"Magnifying Glass: SpawnManager found. DamagedTargetID is: {spawnManager.damagedTargetID}");

                // Check if damagedTargetID is an odd number (1, 3, 5, 7, 9)
                if (spawnManager.damagedTargetID % 2 != 0)
                {
                    audioManager.PlayDamagedItemInspectSFX();
                    Debug.Log($"Magnifying Glass: Playing Damaged Item Inspect SFX because damagedTargetID ({spawnManager.damagedTargetID}) is ODD.");
                }
                else
                {
                    Debug.Log($"Magnifying Glass: DamagedTargetID ({spawnManager.damagedTargetID}) is EVEN. No sound played.");
                }
            }
            else
            {
                Debug.LogWarning("Magnifying Glass: SpawnManager reference is null in OnTriggerEnter2D. Cannot check damagedTargetID.", this);
            }
        }
        else
        {
            Debug.Log($"Magnifying Glass: Collided object ({other.gameObject.name}) does NOT have ItemSpawner component. No sound played.");
        }
    }
    // OR Use OnTriggerEnter if you are using 3D physics
    // void OnTriggerEnter(Collider other)
    // {
    //    Debug.Log($"Magnifying Glass: OnTriggerEnter detected with {other.gameObject.name}.");
    //    // ... (rest of the logic identical to OnTriggerEnter2D, just replace Collider2D with Collider) ...
    // }
    // --------------------------------------------------------
}
