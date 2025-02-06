using NUnit.Framework;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Transform[] locations;
    Transform x;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        x = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            x.position = new Vector3(locations[0].position.x, locations[0].position.y, locations[0].position.z);
        }
        if (Input.GetMouseButtonDown(1))
        {
            x.position = new Vector3(locations[1].position.x, locations[1].position.y, locations[1].position.z);
        }
    }
}
