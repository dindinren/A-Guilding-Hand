using NUnit.Framework;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;  // Ensure you have this line for List<T>


public class CustomerSpawner : MonoBehaviour
{
    // later on can put what we want to spawn
    public List<GameObject> objectsToSpawn = new List<GameObject>();

    public bool isRandomize;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    private void OnMouseDown()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        int index = isRandomize ? Random.Range(0, objectsToSpawn.Count) : 0;

        if (objectsToSpawn.Count > 0)
        {
            //when the game starts, we want it to spawn
            Instantiate(objectsToSpawn[index], transform.position, objectsToSpawn[index].transform.rotation);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
