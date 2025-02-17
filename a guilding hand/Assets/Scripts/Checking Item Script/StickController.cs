using UnityEngine;
using System.Collections;

public class StickController : MonoBehaviour
{
    private Vector3 originalPosition;
    private Color originalColor;

    private bool hasChangedColor = false;  // Track if stick changed color
    private bool indicatorChanged = false; // Track if pH indicator changed color

    private bool isDragging = false;
    private Camera mainCamera;
    private Vector3 offset;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private float returnSpeed = 5f;

    [SerializeField] private Color stickChangedColor = Color.blue;
    [SerializeField] private Color indicatorChangedColor = Color.red;

    void Start()
    {
        originalPosition = transform.position;
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;

            // 🔹 Ensure the stick is always on top by increasing sorting order
            spriteRenderer.sortingOrder = 10; // A higher number ensures it's on top
        }

        // 🔹 Ensure the stick is always rendered on top in 3D by setting its Z position
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
    }

    void OnMouseDown()
    {
        isDragging = true;
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, transform.position.z);
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z) + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        // 🔹 Ensure the stick returns to its original position when released
        StartCoroutine(ReturnToOriginalPosition());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);

        // Stick touches target: Only change if indicator has NOT changed before
        if (other.CompareTag("Target") && !indicatorChanged)
        {
            Debug.Log("Stick touched target, changing color!");
            spriteRenderer.color = stickChangedColor;
            hasChangedColor = true;
        }

        // Stick touches pH indicator
        if (other.CompareTag("Indicator"))
        {
            Debug.Log("Stick touched pH indicator");

            if (hasChangedColor)
            {
                Debug.Log("Stick was changed before, changing pH indicator color!");
                SpriteRenderer indicatorSR = other.GetComponent<SpriteRenderer>();
                if (indicatorSR != null)
                {
                    indicatorSR.color = indicatorChangedColor;
                }

                // Mark the indicator as changed so stick can't change color anymore
                indicatorChanged = true;
            }

            StartCoroutine(ResetStick());
        }
    }

    // 🔹 Returns stick to its original position when the mouse is released
    IEnumerator ReturnToOriginalPosition()
    {
        while (Vector3.Distance(transform.position, originalPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * returnSpeed);
            yield return null;
        }

        transform.position = originalPosition;
    }

    // 🔹 Returns stick to its original color and position after touching pH indicator
    IEnumerator ResetStick()
    {
        Debug.Log("Returning stick to original position and color.");

        spriteRenderer.color = originalColor;
        hasChangedColor = false;

        while (Vector3.Distance(transform.position, originalPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * returnSpeed);
            yield return null;
        }

        transform.position = originalPosition;
    }
}
