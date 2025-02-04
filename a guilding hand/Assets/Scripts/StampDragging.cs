using UnityEngine;
using System.Collections;

public class DragDrop2D : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;
    public string destinationTag = "DropArea";
    private Vector3 originalPosition; // Store the original position of the object

    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        originalPosition = transform.position; // Store the initial position
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        collider2d.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo;

        // Check if the object is dropped in the drop area
        if (hitInfo = Physics2D.Raycast(rayOrigin, rayDirection))
        {
            if (hitInfo.transform.CompareTag(destinationTag))
            {
                // Snap the object to the drop area
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);

                // Destroy the object after 1 second
                StartCoroutine(DestroyAfterDelay(1f)); // Wait for 1 second before destroying
                Debug.Log("Object dropped in the drop area. It will be destroyed in 1 second.");
            }
            else
            {
                // Return to the original position if not dropped in the drop area
                ReturnToOriginalPosition();
            }
        }
        else
        {
            // Return to the original position if no valid drop area is hit
            ReturnToOriginalPosition();
        }

        collider2d.enabled = true;
    }

    // Coroutine to destroy the object after a delay
    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        Debug.Log("Object destroyed!");
    }

    // Method to return the object to its original position
    void ReturnToOriginalPosition()
    {
        transform.position = originalPosition;
        Debug.Log("Returned to original position.");
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}