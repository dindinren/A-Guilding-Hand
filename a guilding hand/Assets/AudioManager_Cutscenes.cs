using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager_Cutscenes : MonoBehaviour
{
    /// <summary>
    /// This is for the CUTSCENES
    /// Why may you ask do I NEED more than ONE AUDIOMANAGER???
    /// 
    /// BECAUSE I DONT KNOW HOW TO CONTROL BETWEEN SCENES 
    /// </summary>
    /// 

    [Header("--------- Audio Source -------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip -------------")]
    public AudioClip CutsceneBGM;

    public AudioClip ClickSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "cutscene 1")
        {
            DontDestroyOnLoad(gameObject);
            musicSource.clip = CutsceneBGM;
            musicSource.Play();
        }

    }

    public void PlayClickSFX(AudioClip clip)
    {
        SFXSource.clip = ClickSFX;
        SFXSource.Play();
        Debug.Log("pop gfoes the weasel");
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            Destroy(gameObject);
            Debug.Log("do you die?");
        }

    }
}
