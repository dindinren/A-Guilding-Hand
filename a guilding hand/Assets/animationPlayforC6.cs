using UnityEngine;

public class animationPlayforC6 : MonoBehaviour
{
    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("Cutscene6_PanUp");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
