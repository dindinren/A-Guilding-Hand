using UnityEngine;
using UnityEngine.SceneManagement;

public class animationPlayforC6 : MonoBehaviour
{
    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        if(SceneManager.GetActiveScene().name == "cutscene 6")
        {
            anim.Play("Cutscene6_PanUp");
        }

        if(SceneManager.GetActiveScene().name == "cutscene 7")
        {
            anim.Play("Cutscene7_PanUp");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
