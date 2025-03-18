using UnityEngine;

public class AudioManager_MainArea : MonoBehaviour
{
    [Header("--------- Audio Source -------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip -------------")]
    public AudioClip MainBGM;
    public AudioClip LostBGM;

    public AudioClip HoverSFX;
    public AudioClip ClickSFX;
    public AudioClip ItemSFX;
    public AudioClip GuidebookFlipSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = MainBGM;
        musicSource.Play();
    }
    //for other scripts to reference and play the sound accordingly
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void GameOver(AudioClip clip)
    {
        musicSource.clip = LostBGM;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
