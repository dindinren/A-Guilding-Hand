using UnityEngine;

public class WhenStartUp : MonoBehaviour
{

    private void Awake()
    {
        int screenW = 1920;
        int screenH = 1080;
        bool isFullscreen = false;

        Screen.SetResolution(screenW, screenH, isFullscreen);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
