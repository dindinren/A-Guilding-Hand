using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject newCameraLocation;
    public GameObject guidebook;
    private Vector3 mainlocation;



    void Start()
    {
        mainCamera = Camera.main.gameObject;
        if (newCameraLocation == null)
        {
            newCameraLocation = GameObject.FindGameObjectWithTag("InitialItemCam");
            
        }
        mainlocation = mainCamera.transform.position;

    }

    private void Update()
    {
        if (mainCamera.transform.position != mainlocation)
        {
            guidebook.gameObject.SetActive(false);
        }
        else
        {
            guidebook.gameObject.SetActive(true);
        }

    }
    void OnMouseDown()
    {
        if (!PauseMenu.instance.isPause)
        {
            //Debug.LogWarning("string");
            Debug.Log($"Moving to new location: {newCameraLocation.transform.position.x}, {newCameraLocation.transform.position.y}, {transform.position.z}");
            guidebook.gameObject.SetActive(false);
            Vector3 oldPos = mainCamera.transform.position;
            mainCamera.transform.position = new Vector3(newCameraLocation.transform.position.x, newCameraLocation.transform.position.y, oldPos.z);

        }



    }

}
