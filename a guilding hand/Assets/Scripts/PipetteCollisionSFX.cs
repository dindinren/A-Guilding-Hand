using UnityEngine;

public class PipetteTipCollisionSFX : MonoBehaviour
{
    [Tooltip("The SFX to play when this PipetteTip collides with a 'Target' or 'pH Test 0'.")]
    public AudioClip tipHitTargetSFX;

    // Flags to ensure the SFX plays only once for each specific tag.
    private bool hasPlayedForTarget = false;
    private bool hasPlayedForPHTest0 = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"PipetteTipCollisionSFX: Collision detected between '{gameObject.name}' (Tag: {gameObject.tag}) and '{other.gameObject.name}' (Tag: {other.gameObject.tag}).");

        // First and foremost, if the colliding object is tagged "Pipette", we completely ignore it.
        // This prevents the sound from playing if the tip's collider somehow interacts with the main pipette body's collider.
        if (other.CompareTag("Pipette"))
        {
            Debug.Log($"PipetteTipCollisionSFX: Collided with 'Pipette' ({other.gameObject.name}). Ignoring this collision for SFX playback.");
            return; // Exit the method immediately.
        }

        // Now, proceed only if it's not the "Pipette" tag.
        // Check if the collided object is a "Target" and the SFX hasn't played for a "Target" yet.
        if (other.CompareTag("Target") && !hasPlayedForTarget)
        {
            Debug.Log($"PipetteTipCollisionSFX: Hit a 'Target' for the first time!");
            PlayTipHitSFX();
            hasPlayedForTarget = true; // Set the flag to true for "Target" collisions.
        }
        // Else, check if the collided object is "pH Test 0" and the SFX hasn't played for "pH Test 0" yet.
        else if (other.CompareTag("pH Test 0") && !hasPlayedForPHTest0)
        {
            Debug.Log($"PipetteTipCollisionSFX: Hit 'pH Test 0' for the first time!");
            PlayTipHitSFX();
            hasPlayedForPHTest0 = true; // Set the flag to true for "pH Test 0" collisions.
        }
        else
        {
            // Log if a collision happened but didn't meet the criteria or already played.
            Debug.Log($"PipetteTipCollisionSFX: Collision with '{other.gameObject.name}' (Tag: {other.gameObject.tag}) ignored (not Target/pH Test 0 or SFX already played for this type).");
        }
    }

    // Helper method to play the SFX and handle common checks
    private void PlayTipHitSFX()
    {
        if (AudioManager_MainArea.Instance != null)
        {
            if (tipHitTargetSFX != null)
            {
                AudioManager_MainArea.Instance.PlaySFX(tipHitTargetSFX);
                Debug.Log("PipetteTipCollisionSFX: Playing 'Tip Hit' SFX.");
            }
            else
            {
                Debug.LogWarning("PipetteTipCollisionSFX: 'Tip Hit Target SFX' is not assigned in the Inspector. Cannot play sound.", this);
            }
        }
        else
        {
            Debug.LogWarning("PipetteTipCollisionSFX: AudioManager_MainArea instance not found. Cannot play 'Tip Hit' SFX.", this);
        }
    }
}