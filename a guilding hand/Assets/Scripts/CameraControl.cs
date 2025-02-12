using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject newCameraLocation;

    void OnMouseDown()
    {
        mainCamera.transform.position = newCameraLocation.transform.position;
    }

}
