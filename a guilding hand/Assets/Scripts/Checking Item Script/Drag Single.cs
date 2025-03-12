using Unity.VisualScripting;
using UnityEngine;

public class DragSingle : MonoBehaviour
{
    Vector3 mousePositionOffset;
    Vector3 startPos;
    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        if (!PauseMenu.instance.isPause)
        {
            mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
            startPos = this.transform.position;
        }

    }

    private void OnMouseDrag()
    {
        if (!PauseMenu.instance.isPause)
        {
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }

    }

    private void OnMouseUp()
    {
        if (!PauseMenu.instance.isPause)
        {
            this.transform.position = startPos;
        }
    }
}
