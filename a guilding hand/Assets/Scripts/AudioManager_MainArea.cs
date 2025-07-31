using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AudioManager_MainArea : MonoBehaviour
{
    public static AudioManager_MainArea Instance { get; private set; }

    [Header("--------- Audio Source -------------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("--------- Background Music Clips -------------")]
    public AudioClip MainBGM;
    public AudioClip LostBGM;
    public AudioClip WinBGM;

    [Header("--------- General SFX Clips -------------")]
    [Tooltip("An array of AudioClips for general hover sounds, one will be chosen randomly.")]
    public AudioClip[] GeneralHoverSFXs;
    public AudioClip ClickSFX; // General click sound (fallback if no specific tag match)
    public AudioClip ItemSFX;
    public AudioClip ItemSFXClick;
    public AudioClip[] GuidebookFlipSFXs;
    public AudioClip Walk;
    public AudioClip Stamp;
    public AudioClip pHDrop;
    public AudioClip pHGet;
    public AudioClip PlayerHappySound;
    public AudioClip PlayerSadSound;
    public AudioClip GuidebookHoverSFX;
    public AudioClip DamagedItemInspectSFX;

    // ***** NEW: Cooldown variables for DamagedItemInspectSFX *****
    private float lastDamagedItemInspectTime;
    [Tooltip("Cooldown duration for DamagedItemInspectSFX in seconds.")]
    public float damagedItemInspectCooldown = 1.5f; // Default to 1 second, adjustable in Inspector
    // ************************************************************

    // ***** UPDATED: Specific SFX for Click/Drag Start by Tag (for Stamps, Buttons, etc.) *****
    [Header("--------- Tag-Specific Click SFX -------------")]
    [Tooltip("Assign specific audio clips to play when objects with matching tags are clicked.")]
    public List<TagAudioClip> taggedClickSFXs;

    // ***** NEW: Specific SFX for Hover by Tag (for Buttons) *****
    [Header("--------- Tag-Specific Hover SFX -------------")]
    [Tooltip("Assign specific audio clips to play when the mouse hovers over objects with matching tags.")]
    public List<TagAudioClip> taggedHoverSFXs;

    // --- CONSOLIDATED CUSTOMER AUDIO PROFILES ---
    [Header("--------- Customer Audio Profiles -------------")]
    [Tooltip("Assign all specific audio clips for each customer type here.")]
    public List<CustomerAudioProfile> customerAudioProfiles; // Single list for all customer-related audio

    private Coroutine currentFootstepStopCoroutine;
    private const float FOOTSTEP_MAX_DURATION = 1.0f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject); // Uncomment if needed
        }
    }

    void Start()
    {
        if (musicSource != null && MainBGM != null)
        {
            musicSource.clip = MainBGM;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioManager_MainArea: Music source or Main BGM not assigned.", this);
        }

        lastDamagedItemInspectTime = -damagedItemInspectCooldown;
    }

    // --- Core SFX Playback Method ---
    public void PlaySFX(AudioClip clip)
    {
        if (SFXSource != null && clip != null)
        {
            SFXSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("AudioManager_MainArea: Attempted to play a null AudioClip or SFXSource is not assigned.", this);
        }
    }

    public void PlaySFXForTaggedClick(string objectTag)
    {
        if (taggedClickSFXs != null && taggedClickSFXs.Count > 0)
        {
            foreach (var entry in taggedClickSFXs)
            {
                if (entry.tag == objectTag)
                {
                    if (entry.audioClip != null)
                    {
                        PlaySFX(entry.audioClip);
                        Debug.Log($"Playing specific click SFX for tag: {objectTag}");
                        return;
                    }
                    else
                    {
                        Debug.LogWarning($"AudioManager_MainArea: Click sound for tag '{objectTag}' is assigned but the AudioClip is null. Playing general ClickSFX as fallback.", this);
                        break;
                    }
                }
            }
        }
        if (ClickSFX != null)
        {
            PlaySFX(ClickSFX);
            Debug.Log($"No specific click SFX for tag '{objectTag}' found or assigned. Playing general ClickSFX.");
        }
        else
        {
            Debug.LogWarning($"AudioManager_MainArea: No specific click sound configured for tag '{objectTag}' and general ClickSFX is also null.", this);
        }
    }

    public void PlaySFXForTaggedHover(string objectTag)
    {
        if (taggedHoverSFXs != null && taggedHoverSFXs.Count > 0)
        {
            foreach (var entry in taggedHoverSFXs)
            {
                if (entry.tag == objectTag)
                {
                    if (entry.audioClip != null)
                    {
                        PlaySFX(entry.audioClip);
                        Debug.Log($"Playing specific hover SFX for tag: {objectTag}");
                        return;
                    }
                    else
                    {
                        Debug.LogWarning($"AudioManager_MainArea: Hover sound for tag '{objectTag}' is assigned but the AudioClip is null. No hover sound played.", this);
                        return;
                    }
                }
            }
        }
        if (GeneralHoverSFXs != null && GeneralHoverSFXs.Length > 0)
        {
            PlayGeneralHoverSFX();
            Debug.Log($"No specific hover SFX for tag '{objectTag}' found or assigned. Playing general hover SFX.");
        }
        else
        {
            Debug.LogWarning("AudioManager_MainArea: No specific hover sound configured for tag '{objectTag}' and general hover SFX array is empty or null.", this);
        }
    }

    // --- MODIFIED: PlayCustomerFootstepSFX using CustomerAudioProfile ---
    public void PlayCustomerFootstepSFX(string customerTag)
    {
        Debug.Log($"AudioManager_MainArea: Attempting to play footstep sound for requested tag: '{customerTag}'");

        if (customerAudioProfiles == null || customerAudioProfiles.Count == 0)
        {
            Debug.LogWarning("AudioManager_MainArea: 'customerAudioProfiles' list is empty or not assigned. Cannot play tagged footstep sound.", this);
            return;
        }

        foreach (var profile in customerAudioProfiles)
        {
            if (profile.customerTag == customerTag) // Found a matching tag
            {
                if (profile.footstepSound != null)
                {
                    Debug.Log($"AudioManager_MainArea: SUCCESS! Playing footstep sound '{profile.footstepSound.name}' for tag '{customerTag}'.");

                    SFXSource.Stop(); // Stop current footstep before playing a new one
                    if (currentFootstepStopCoroutine != null)
                    {
                        StopCoroutine(currentFootstepStopCoroutine);
                    }
                    SFXSource.PlayOneShot(profile.footstepSound);
                    currentFootstepStopCoroutine = StartCoroutine(StopFootstepAfterDelay(FOOTSTEP_MAX_DURATION));
                    return;
                }
                else
                {
                    Debug.LogWarning($"AudioManager_MainArea: Footstep sound for tag '{customerTag}' is assigned but the AudioClip is null. Please assign an audio clip for this entry.", this);
                    return; // Found profile, but sound is null
                }
            }
        }
        Debug.LogWarning($"AudioManager_MainArea: No customer audio profile found for customer tag '{customerTag}'. Check if tag is misspelled or missing in AudioManager_MainArea Inspector.", this);
    }

    // --- NEW/MODIFIED: PlayCustomerItemInteractionSFX using CustomerAudioProfile ---
    public void PlayCustomerItemInteractionSFX(string customerTag)
    {
        if (customerAudioProfiles == null || customerAudioProfiles.Count == 0)
        {
            Debug.LogWarning("AudioManager_MainArea: 'customerAudioProfiles' list is empty or not assigned. Cannot play customer item interaction sound.", this);
            return;
        }

        foreach (var profile in customerAudioProfiles)
        {
            if (profile.customerTag == customerTag)
            {
                if (profile.itemInteractionSFXClips != null && profile.itemInteractionSFXClips.Length > 0)
                {
                    // Pick a random clip from the assigned array
                    int randomIndex = Random.Range(0, profile.itemInteractionSFXClips.Length);
                    AudioClip chosenClip = profile.itemInteractionSFXClips[randomIndex];

                    if (chosenClip != null)
                    {
                        PlaySFX(chosenClip);
                        Debug.Log($"Playing random item interaction SFX '{chosenClip.name}' for customer tag: {customerTag}");
                    }
                    else
                    {
                        Debug.LogWarning($"AudioManager_MainArea: Customer item interaction SFX for tag '{customerTag}' has a null AudioClip at index {randomIndex}. Please check your assignments.", this);
                    }
                }
                else
                {
                    Debug.LogWarning($"AudioManager_MainArea: Customer item interaction SFX for tag '{customerTag}' has an empty or null AudioClip array. No sound played.", this);
                }
                return; // Found the customer tag, so we're done.
            }
        }
        Debug.LogWarning($"AudioManager_MainArea: No customer audio profile found for customer tag '{customerTag}'. Check if tag is misspelled or missing in AudioManager_MainArea Inspector.", this);
    }

    // --- All your other existing methods remain below ---
    public void PlayGeneralHoverSFX()
    {
        if (GeneralHoverSFXs != null && GeneralHoverSFXs.Length > 0)
        {
            int randomIndex = Random.Range(0, GeneralHoverSFXs.Length);
            if (GeneralHoverSFXs[randomIndex] != null)
            {
                SFXSource.PlayOneShot(GeneralHoverSFXs[randomIndex]);
            }
            else
            {
                Debug.LogWarning($"GeneralHoverSFXs: Randomly selected AudioClip at index {randomIndex} is null. Please assign an AudioClip to all slots.", this);
            }
        }
        else
        {
            Debug.LogWarning("GeneralHoverSFXs array is empty or null. Please assign audio clips in the Inspector for general hover sounds.", this);
        }
    }

    public void PlayGuidebookHoverSFX()
    {
        if (GuidebookHoverSFX != null)
        {
            SFXSource.PlayOneShot(GuidebookHoverSFX);
        }
        else
        {
            Debug.LogWarning("GuidebookHoverSFX is not assigned in AudioManager_MainArea. Cannot play hover sound.", this);
        }
    }

    public void PlayRandomGuidebookFlipSFX()
    {
        if (GuidebookFlipSFXs != null && GuidebookFlipSFXs.Length > 0)
        {
            int randomIndex = Random.Range(0, GuidebookFlipSFXs.Length);
            if (GuidebookFlipSFXs[randomIndex] != null)
            {
                SFXSource.PlayOneShot(GuidebookFlipSFXs[randomIndex]);
            }
            else
            {
                Debug.LogWarning($"GuidebookFlipSFXs: Randomly selected AudioClip at index {randomIndex} is null. Please assign an AudioClip to all slots.", this);
            }
        }
        else
        {
            Debug.LogWarning("GuidebookFlipSFXs array is empty or null. Please assign audio clips in the Inspector.", this);
        }
    }

    public void PlayDamagedItemInspectSFX()
    {
        if (DamagedItemInspectSFX != null)
        {
            if (Time.time >= lastDamagedItemInspectTime + damagedItemInspectCooldown)
            {
                SFXSource.PlayOneShot(DamagedItemInspectSFX);
                lastDamagedItemInspectTime = Time.time;
            }
            else
            {
                Debug.Log($"DamagedItemInspectSFX is on cooldown. Next play available in: {Mathf.Max(0, (lastDamagedItemInspectTime + damagedItemInspectCooldown) - Time.time):F2} seconds.");
            }
        }
        else
        {
            Debug.LogWarning("DamagedItemInspectSFX is not assigned in AudioManager_MainArea. Cannot play sound.", this);
        }
    }

    private IEnumerator StopFootstepAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SFXSource.Stop();
        currentFootstepStopCoroutine = null;
    }

    public void GameOver(AudioClip clip)
    {
        musicSource.clip = LostBGM;
        musicSource.Play();
        musicSource.loop = false;
    }

    public void YouWin(AudioClip clip)
    {
        musicSource.clip = WinBGM;
        musicSource.Play();
        musicSource.loop = false;
    }

    void Update()
    {
        // Your Update logic here (if any)
    }
}

// Custom Struct (outside the class definition) for tag-audio clip pairs
[System.Serializable]
public struct TagAudioClip
{
    public string tag;
    public AudioClip audioClip;
}