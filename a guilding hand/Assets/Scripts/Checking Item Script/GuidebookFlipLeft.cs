using UnityEngine;

public class GuidebookFlipLeft : MonoBehaviour
{
    public GuidebookpHManager guidebookpHManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        guidebookpHManager.Backward();
    }
}
