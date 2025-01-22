using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerSpawner : MonoBehaviour
{
    // List of customers to spawn
    public List<GameObject> CustomersToSpawn = new List<GameObject>();

    public GameObject spawner;

    //time for the items to spawn
    public float itemstimetospawn;
    public float currenttimetospawn;

    // Flag to randomize the object selection
    public bool isRandomize;

    // Reference to the last spawned object
    private GameObject lastSpawnedObject;

    void Start()
    {
        // You can initialize things here if necessary
    }

    private void OnMouseDown()
    {
        // Only spawn an object if there isn't already a spawned object
        if (lastSpawnedObject == null)
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        int index = isRandomize ? Random.Range(0, CustomersToSpawn.Count) : 0;

        if (CustomersToSpawn.Count > 0)
        {
            // Instantiate the object at the current position and rotation of this object
            lastSpawnedObject = Instantiate(CustomersToSpawn[index], transform.position, CustomersToSpawn[index].transform.rotation);

            Debug.Log("Customer Spawned!");

            // Start a coroutine to destroy the object after 1 second
            //StartCoroutine(DestroyAfterDelay(lastSpawnedObject, 3f));
        }
    }

    //// Coroutine to destroy the object after a delay
    //IEnumerator DestroyAfterDelay(GameObject spawnedObject, float delay)
    //{
    //    // Wait for the specified amount of time
    //    yield return new WaitForSeconds(delay);

    //    // Destroy the spawned object after the delay
    //    Destroy(spawnedObject);

    //    // Allow the user to click again after the object is destroyed
    //    lastSpawnedObject = null;
    //}

    void Update()
    {
        // Any logic you need per frame can go here
    }
}
