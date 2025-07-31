using UnityEngine;
using Unity.VisualScripting; // Keep this if you need it for other parts of your script

public class DragSingle : MonoBehaviour
{
    Vector3 mousePositionOffset;
    Vector3 startPos;

    // REMOVED: No longer need to manually find or store AudioManager.
    // AudioManager_MainArea audioManager;
    SpawnManager spawnManager;

    private void Awake()
    {
        // REMOVED: No longer need to manually find AudioManager, will use its Instance.
        // audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_MainArea>();
        // if (audioManager == null)
        // {
        //     Debug.LogError("DragSingle Awake: AudioManager_MainArea not found! Make sure it's in the scene and tagged 'AudioManager'.", this);
        // }

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
            // ***** KEY CHANGE: Use AudioManager_MainArea.Instance.PlaySFXForTaggedClick() *****
            if (AudioManager_MainArea.Instance != null)
            {
                // This will play the SFX configured in AudioManager's 'taggedClickSFXs'
                // list that matches the tag of *this* GameObject (which should be "Pipette").
                AudioManager_MainArea.Instance.PlaySFXForTaggedClick(gameObject.tag);
                Debug.Log($"DragSingle: Mouse Down - Specific SFX played for tag: {gameObject.tag}");
            }
            else
            {
                Debug.LogWarning("DragSingle OnMouseDown: AudioManager_MainArea instance not found. Cannot play click SFX.", this);
            }

            mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
            startPos = this.transform.position;
        }
    }

    private void OnMouseDrag()
    {
        if (!PauseMenu.instance.isPause)
        {
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }
    }

    private void OnMouseUp()
    {
        if (!PauseMenu.instance.isPause)
        {
            this.transform.position = startPos;
            Debug.Log("Pipette: Mouse Up - Returned to start position.");
        }
    }

    // --- Collision Detection with detailed logs ---
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Pipette: OnTriggerEnter2D detected with {other.gameObject.name}.");

        ItemSpawner itemSpawner = other.GetComponent<ItemSpawner>();
        if (itemSpawner != null)
        {
            Debug.Log("Pipette: Collided object has ItemSpawner component.");

            if (spawnManager != null)
            {
                Debug.Log($"Pipette: SpawnManager found. DamagedTargetID is: {spawnManager.damagedTargetID}");

                if (spawnManager.damagedTargetID % 2 != 0) // Check if damagedTargetID is an odd number
                {
                    if (AudioManager_MainArea.Instance != null)
                    {
                        AudioManager_MainArea.Instance.PlayDamagedItemInspectSFX();
                        Debug.Log($"Pipette: Playing Damaged Item Inspect SFX because damagedTargetID ({spawnManager.damagedTargetID}) is ODD.");
                    }
                    else
                    {
                        Debug.LogWarning("Pipette OnTriggerEnter2D: AudioManager_MainArea instance not found. Cannot play Damaged Item Inspect SFX.", this);
                    }
                }
                else
                {
                    Debug.Log($"Pipette: DamagedTargetID ({spawnManager.damagedTargetID}) is EVEN. No sound played.");
                }
            }
            else
            {
                Debug.LogWarning("Pipette: SpawnManager reference is null in OnTriggerEnter2D. Cannot check damagedTargetID.", this);
            }
        }
        else
        {
            Debug.Log($"Pipette: Collided object ({other.gameObject.name}) does NOT have ItemSpawner component. No sound played.");
        }
    }
}
