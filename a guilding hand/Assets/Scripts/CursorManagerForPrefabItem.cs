using System.Collections;
using UnityEngine;

public class CursorManagerForPrefabItem : MonoBehaviour
{
    /// <summary>
    /// PLS NOTE THAT THIS NOT NECESSARILY FOUND IN PREFABs
    /// AS I DISCOVER THIS SCRIPT CAN BE USED IN OTHER INTERACTABLES OTHER THAN THE COMPONENTS THAT DRAGS
    /// </summary>

    public Texture2D cursorTexture;
    public Texture2D cursorItemChange;
    public Vector2 cursorHotspot;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnMouseEnter()
    {

        Cursor.SetCursor(cursorItemChange, cursorHotspot, CursorMode.Auto);

        //if(Input.GetMouseButtonDown(0))
        //{
        //    Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        //    Cursor.SetCursor(cursorItemChange, cursorHotspot, CursorMode.Auto);
        //}

    }

    public void OnMouseDown()
    {
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);


       // Cursor.SetCursor(cursorItemChange, cursorHotspot, CursorMode.Auto);

    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }

}
