using UnityEngine;

public class CursorManagerForGuidebook : MonoBehaviour
{
    /// <summary>
    /// WHY IS THERE A NEED FOR A SEPERATE CODE FOR GUIDEBOOK??
    /// BECAUSE IF I WERE TO USE THE CursorManagerforPrefabItem script, the cursor will change 
    /// THIS IS TO PREVENT THAT 
    /// ONCE AGAIN IM SORRY FOR THIS SHITTY COMPRIMISE
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

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
            Cursor.SetCursor(cursorItemChange, cursorHotspot, CursorMode.Auto);
        }

    }

    //public void OnMouseDown()
    //{
    //    Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    //    Cursor.SetCursor(cursorItemChange, cursorHotspot, CursorMode.Auto);

    //}

    public void OnMouseExit()
    {
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }

}
