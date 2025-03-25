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

    public AudioClip HoverSFX;
    public AudioClip ClickSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = MenuBGM;
        musicSource.Play();
    }

    public void PlayHoverSFX(AudioClip clip)
    {
        SFXSource.clip = HoverSFX;
        SFXSource.Play();
    }

    public void PlayClickSFX (AudioClip clip)
    {
        SFXSource.clip = ClickSFX;
        SFXSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
