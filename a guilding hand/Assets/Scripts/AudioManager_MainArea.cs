using UnityEngine;

public class AudioManager_MainArea : MonoBehaviour
{
    [Header("--------- Audio Source -------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip -------------")]
    public AudioClip MainBGM;
    public AudioClip LostBGM;
    public AudioClip WinBGM;

    public AudioClip HoverSFX;
    public AudioClip ClickSFX;
    public AudioClip ItemSFX;
    public AudioClip ItemSFXClick;
    public AudioClip GuidebookFlipSFX;
    public AudioClip Walk;
    public AudioClip Stamp;
    public AudioClip pHDrop;
    public AudioClip pHGet;
    public AudioClip PlayerHappySound;
    public AudioClip PlayerSadSound;
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
        musicSource.loop = false;
    }

    public void YouWin(AudioClip clip)
    {
        musicSource.clip = WinBGM;
        musicSource.Play();
        musicSource.loop = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
