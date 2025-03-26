using UnityEngine;

public class AudioManager_Credits : MonoBehaviour
{
    [Header("--------- Audio Source -------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip -------------")]
    public AudioClip CreditsBGM;

    public AudioClip HoverSFX;
    public AudioClip ClickSFX;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = CreditsBGM;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHoverSFX(AudioClip clip)
    {
        SFXSource.clip = HoverSFX;
        SFXSource.Play();
    }

    public void PlayClickSFX(AudioClip clip)
    {
        SFXSource.clip = ClickSFX;
        SFXSource.Play();
    }
}
