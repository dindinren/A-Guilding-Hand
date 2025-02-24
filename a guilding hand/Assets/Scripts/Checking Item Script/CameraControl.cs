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
        //Debug.LogWarning("string");
        Debug.Log($"Moving to new location: {newCameraLocation.transform.position.x}, {newCameraLocation.transform.position.y}, {transform.position.z}");
        Vector3 oldPos = mainCamera.transform.position;
        mainCamera.transform.position = new Vector3(newCameraLocation.transform.position.x,newCameraLocation.transform.position.y, oldPos.z);
    }

}
