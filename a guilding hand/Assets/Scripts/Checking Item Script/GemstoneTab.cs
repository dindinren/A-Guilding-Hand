using UnityEngine;

public class GemstoneTab : MonoBehaviour
{
    public GuidebookpHManager GuidebookpHManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        GuidebookpHManager.SkipToGemstone();
    }
}
