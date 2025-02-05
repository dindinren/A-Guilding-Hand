using UnityEngine;
using System.Collections;

public class DragDrop2D : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;
    public string destinationTag = "DropArea";
    private Vector3 originalPosition; // Store the original position of the object

    public GameObject tick;
    public AnimationCurve temp;

    private bool returncheck;

    public CustomerSpawner customerspawner;

     
    private void Start()
    {
        tick.SetActive(false);
    }
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
                StartCoroutine(DestroyAndRespawnAfterDelay(1f)); // Wait for 1 second before destroying and respawning
                Debug.Log("Object dropped in the drop area. It will be destroyed and respawned.");

                customerspawner.CustomerDelete();
            }
            else
            {
                returncheck = true;
                // Return to the original position if not dropped in the drop area
                //ReturnToOriginalPosition();
            }
        }
        else
        {
            // Return to the original position if no valid drop area is hit
            returncheck = true;
        }

        collider2d.enabled = true;
    }

    // Coroutine to destroy the object and respawn it after a delay
    IEnumerator DestroyAndRespawnAfterDelay(float delay)
    {
        tick.SetActive(true);
        float elapsed = 0f;
        float duration = 1f;
        Vector2 startPos = transform.position;
        
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float ease = temp.Evaluate(t);
            transform.position = Vector2.Lerp(startPos, originalPosition, ease);

            elapsed += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(delay);

        //// Destroy the current object
        //Destroy(gameObject);

        GameObject[] obj = GameObject.FindGameObjectsWithTag("QuestItemObject");
        foreach(GameObject ob in obj)
        {
            Destroy(ob);
        }
        GameObject[] obj2 = GameObject.FindGameObjectsWithTag("QuestFormObject");
        foreach (GameObject ob2 in obj2)
        {
            Destroy(ob2);
        }
        GameObject[] obj3 = GameObject.FindGameObjectsWithTag("AdventureFormObject");
        foreach (GameObject ob3 in obj3)
        {
            Destroy(ob3);
        }
        Debug.Log("Object destroyed!");

        tick.SetActive(false);

        //// Respawn the object at its original position
        //RespawnObject();
    }

    //// Method to respawn the object at its original position
    //void RespawnObject()
    //{
    //    // Instantiate a new object at the original position
    //    GameObject newObject = Instantiate(gameObject, originalPosition, Quaternion.identity);

    //    // Ensure the new object has the same script and properties
    //    DragDrop2D newDragDrop = newObject.GetComponent<DragDrop2D>();
    //    if (newDragDrop != null)
    //    {
    //        newDragDrop.originalPosition = originalPosition; // Set the original position for the new object
    //        newDragDrop.collider2d.enabled = true; // Ensure the new object's collider is enabled
    //    }

    //    Debug.Log("Object respawned at original position!");
    //}

    // Method to return the object to its original position

    private void FixedUpdate()
    {
        if (returncheck == true)
        {
            ReturnToOriginalPosition();
        }
    }
    void ReturnToOriginalPosition()
    {
        float elapsed = 0f;
        float duration = 1f;
        Vector2 startPos = transform.position;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float ease = temp.Evaluate(t);
            transform.position = Vector2.Lerp(startPos, originalPosition, ease);

            elapsed += Time.deltaTime;
        }
        Debug.Log("Returned to original position.");
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}