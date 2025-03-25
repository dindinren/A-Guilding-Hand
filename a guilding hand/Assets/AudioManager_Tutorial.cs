using UnityEngine;

public class AudioManager_Tutorial : MonoBehaviour
{
    [Header("--------- Audio Source -------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip -------------")]
    public AudioClip tutorialBGM;

    public AudioClip HoverSFX;
    public AudioClip ClickSFX;
    public AudioClip GuidebookFlipSFX;    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = tutorialBGM;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
