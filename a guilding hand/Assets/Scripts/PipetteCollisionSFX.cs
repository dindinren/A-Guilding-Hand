using UnityEngine;

public class PipetteTipCollisionSFX : MonoBehaviour
{
    [Tooltip("The SFX to play when this PipetteTip collides with a 'Target'.")]
    public AudioClip tipHitTargetSFX;

    // This method is called when this object's collider (which must be a Trigger)
    // touches another object's collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"PipetteTipCollisionSFX: Collision detected between '{gameObject.name}' (Tag: {gameObject.tag}) and '{other.gameObject.name}' (Tag: {other.gameObject.tag}).");

        // Check if the collided object has the "Target" tag.
        if (other.CompareTag("Target"))
        {
            Debug.Log($"PipetteTipCollisionSFX: Hit a 'Target'!");

            // Play the specific SFX using the AudioManager singleton.
            if (AudioManager_MainArea.Instance != null)
            {
                if (tipHitTargetSFX != null)
                {
                    AudioManager_MainArea.Instance.PlaySFX(tipHitTargetSFX);
                    Debug.Log("PipetteTipCollisionSFX: Playing 'Tip Hit Target' SFX.");
                }
                else
                {
                    Debug.LogWarning("PipetteTipCollisionSFX: 'Tip Hit Target SFX' is not assigned in the Inspector. Cannot play sound.", this);
                }
            }
            else
            {
                Debug.LogWarning("PipetteTipCollisionSFX: AudioManager_MainArea instance not found. Cannot play 'Tip Hit Target' SFX.", this);
            }
        }
    }

    // You can add OnTriggerExit2D if you need to detect when the tip leaves the target.
    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.CompareTag("Target"))
    //     {
    //         Debug.Log("PipetteTipCollisionSFX: Left the 'Target'.");
    //     }
    // }
}