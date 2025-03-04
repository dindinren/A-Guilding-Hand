using System.ComponentModel.Design;
using UnityEngine;

public class CornerHPManager : MonoBehaviour
{

    public Camera Camera;
    public GameObject PlayerExpressions;
    public GameObject HealthGroup;
    private Transform cameraTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraTransform = Camera.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTransform.position.x == 0) //Main
        {
            PlayerExpressions.SetActive(true);
            HealthGroup.SetActive(true);
        }
        else
        {
            PlayerExpressions.SetActive(false);
            HealthGroup.SetActive(false);
        }
        
    }
}