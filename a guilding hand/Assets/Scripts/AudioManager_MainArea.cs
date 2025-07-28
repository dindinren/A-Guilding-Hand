using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AudioManager_MainArea : MonoBehaviour
{
    [Header("--------- Audio Source -------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip -------------")]
    public AudioClip MainBGM;
    public AudioClip LostBGM;
    public AudioClip WinBGM;

    // --- NEW: General Hover SFXs (array for randomization) ---
    [Tooltip("An array of AudioClips for general hover sounds, one will be chosen randomly.")]
    public AudioClip[] GeneralHoverSFXs;
    // -----------------------------------------------------------

    public AudioClip ClickSFX;
    public AudioClip ItemSFX;
    public AudioClip ItemSFXClick;
    public AudioClip[] GuidebookFlipSFXs;
    public AudioClip Walk;
    public AudioClip Stamp;
    public AudioClip pHDrop;
    public AudioClip pHGet;
    public AudioClip PlayerHappySound;
    public AudioClip PlayerSadSound;

    public AudioClip GuidebookHoverSFX; // Specific hover for MainAreaGuideBook
    public AudioClip DamagedItemInspectSFX; // Specific for damaged item inspect

    [Header("--------- Customer Footstep SFX by Tag -------------")]
    [Tooltip("Assign footstep sounds for each customer type here by their GameObject Tag.")]
    public List<CustomerFootstepAudio> customerFootstepAudios;

    private Coroutine currentFootstepStopCoroutine;
    private const float FOOTSTEP_MAX_DURATION = 1.0f;

    void Start()
    {
        musicSource.clip = MainBGM;
        musicSource.Play();
    }

    // This method will play any specific AudioClip provided
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            SFXSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Attempted to play a null AudioClip via PlaySFX.", this);
        }
    }

    // --- NEW: Method to play a random General Hover SFX ---
    public void PlayGeneralHoverSFX()
    {
        if (GeneralHoverSFXs != null && GeneralHoverSFXs.Length > 0)
        {
            int randomIndex = Random.Range(0, GeneralHoverSFXs.Length);
            // Ensure the chosen clip is not null before playing
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
    // --------------------------------------------------------

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
            SFXSource.PlayOneShot(DamagedItemInspectSFX);
        }
        else
        {
            Debug.LogWarning("DamagedItemInspectSFX is not assigned in AudioManager_MainArea. Cannot play sound.", this);
        }
    }

    public void PlayCustomerFootstepSFX(string customerTag)
    {
        Debug.Log($"AudioManager_MainArea: Attempting to play sound for requested tag: '{customerTag}'");

        if (customerFootstepAudios == null || customerFootstepAudios.Count == 0)
        {
            Debug.LogWarning("AudioManager_MainArea: 'customerFootstepAudios' list is empty or not assigned. Cannot play tagged footstep sound.", this);
            return;
        }

        foreach (var audioEntry in customerFootstepAudios)
        {
            Debug.Log($"AudioManager_MainArea: Comparing requested tag '{customerTag}' with configured entry tag '{audioEntry.customerTag}'. Match? {audioEntry.customerTag == customerTag}");
            if (audioEntry.customerTag == customerTag) // Found a matching tag
            {
                if (audioEntry.footstepSound != null)
                {
                    Debug.Log($"AudioManager_MainArea: SUCCESS! Playing sound '{audioEntry.footstepSound.name}' for tag '{customerTag}'.");

                    SFXSource.Stop();
                    if (currentFootstepStopCoroutine != null)
                    {
                        StopCoroutine(currentFootstepStopCoroutine);
                    }

                    SFXSource.PlayOneShot(audioEntry.footstepSound);

                    currentFootstepStopCoroutine = StartCoroutine(StopFootstepAfterDelay(FOOTSTEP_MAX_DURATION));

                    return;
                }
                else
                {
                    Debug.LogWarning($"AudioManager_MainArea: Footstep sound for tag '{customerTag}' is assigned but the AudioClip is null. Please assign an audio clip for this entry.", this);
                }
            }
        }

        Debug.LogWarning($"AudioManager_MainArea: No footstep sound configuration found for customer tag '{customerTag}'. Check if tag is misspelled or missing in AudioManager_MainArea Inspector.", this);
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

    }
}