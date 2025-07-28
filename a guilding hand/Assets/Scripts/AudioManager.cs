using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// This is ONLY for the MENU ONLY
    /// </summary>


    [Header("--------- Audio Source -------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip -------------")]
    public AudioClip MenuBGM;
    public AudioClip CutsceneBGM;

    // CHANGED: From single AudioClip to an array for randomization
    public AudioClip[] HoverSFXs;
    public AudioClip ClickSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour created
    void Start()
    {
        musicSource.clip = MenuBGM;
        musicSource.Play();
    }

    // MODIFIED: This method now plays a random clip from the HoverSFXs array
    public void PlayHoverSFX(AudioClip clip) // Keep the 'clip' parameter for compatibility, though it's not used internally for HoverSFX logic
    {
        if (HoverSFXs != null && HoverSFXs.Length > 0)
        {
            int randomIndex = Random.Range(0, HoverSFXs.Length);
            SFXSource.PlayOneShot(HoverSFXs[randomIndex]); // Use PlayOneShot for SFX
        }
        else
        {
            Debug.LogWarning("HoverSFXs array is empty or null. Please assign audio clips in the Inspector for hover sounds.");
        }
    }

    public void PlayClickSFX(AudioClip clip)
    {
        SFXSource.clip = ClickSFX;
        SFXSource.Play();
    }
    // Update is called once per frame
    void Update()
    {

    }
}