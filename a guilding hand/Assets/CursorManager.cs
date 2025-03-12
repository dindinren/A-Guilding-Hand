using System.Runtime.CompilerServices;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Vector2 cursorHotspot;

    public Texture2D cursorStampDetect;
    public Texture2D cursorStampDrag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseEnter()
    {
        if (!PauseMenu.instance.isPause)
        {
            Cursor.SetCursor(cursorStampDetect, cursorHotspot, CursorMode.Auto);
        }
    }

    private void OnMouseDrag()
    {
        if (!PauseMenu.instance.isPause)
        {
            Cursor.SetCursor(cursorStampDrag, cursorHotspot, CursorMode.Auto);
        }
    }
    private void OnMouseUp()
    {
        if(!PauseMenu.instance.isPause)
        {
            Cursor.SetCursor(cursorStampDetect, cursorHotspot, CursorMode.Auto);
        }
    }

    private void OnMouseExit()
    {
        if (!PauseMenu.instance.isPause)
        {
            Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        }

    }




}
