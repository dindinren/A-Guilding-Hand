using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gobacktomainafterdelay : MonoBehaviour
{
    public float delayTime = 5f;
    void Start()
    {
        Invoke("GoToMain", delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToMain()
    {
        SceneManager.LoadScene("Menu");
    }
}
