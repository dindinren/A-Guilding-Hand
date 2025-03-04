using UnityEngine;

public class InstructionsTab : MonoBehaviour
{
    public GuidebookpHManager GuidebookpHManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        GuidebookpHManager.SkipToInstructions();
    }
}
