using UnityEngine;
using UnityEngine.Rendering;

public class CameraControl : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject newCameraLocation;


    void Start()
    {
        mainCamera = Camera.main.gameObject;
        if (newCameraLocation == null)
        {
            newCameraLocation = GameObject.FindGameObjectWithTag("InitialItemCam");
        }
    }
    void OnMouseDown()
    {
        Debug.LogWarning("string");
        mainCamera.transform.position = newCameraLocation.transform.position;
    }

}
