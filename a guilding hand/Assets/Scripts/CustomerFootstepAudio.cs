// NEW: Custom Class for a comprehensive Customer Audio Profile
using UnityEngine;

[System.Serializable]
public class CustomerAudioProfile
{
    [Tooltip("The exact Tag of the customer GameObject (e.g., 'ElfMage', 'Knight', 'CatArcher', 'NatureLover').")]
    public string customerTag;

    [Tooltip("The specific footstep sound for this customer tag.")]
    public AudioClip footstepSound;

    [Tooltip("An array of two (or more) AudioClips for random item interaction SFX for this customer.")]
    public AudioClip[] itemInteractionSFXClips = new AudioClip[2]; // Pre-allocate for 2 clips
}