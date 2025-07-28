using UnityEngine;

// This makes the class visible in the Unity Inspector
[System.Serializable]
public class CustomerFootstepAudio
{
    [Tooltip("The exact Tag of the customer GameObject (e.g., 'ElfMage', 'Knight', 'CatArcher', 'NatureLover').")]
    public string customerTag;

    [Tooltip("The specific footstep sound for this customer tag.")]
    public AudioClip footstepSound;
}