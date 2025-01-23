using UnityEngine;

public class Raycast2DExample : MonoBehaviour
{
    public float rayDistance = 5f;  // Distance of the ray
    public LayerMask layerMask;    // Layer mask to filter collisions

    void Update()
    {
        /*
        // Draw the ray in the Scene view for visualization
        Debug.DrawRay(transform.position, Vector2.right * rayDistance, Color.red);

        // Check if the ray hit something
        if (hit.collider != null)
        {
            Debug.Log("Hit object: " + hit.collider.name);
        }*/
    }
}
