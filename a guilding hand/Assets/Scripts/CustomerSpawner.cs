using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerSpawner : MonoBehaviour
{
    // List of customers to spawn
    public List<GameObject> CustomersToSpawn = new List<GameObject>();

    public GameObject spawner;

    // Time for the items to spawn
    public float itemstimetospawn;
    public float currenttimetospawn;

    public float delay = 1f;

    // Flag to randomize the object selection
    public bool isRandomize;

    // Reference to the last spawned object
    private GameObject lastSpawnedObject;

    void Start()
    {
        // Start the coroutine to spawn the object after the delay
        StartCoroutine(SpawnObjectAfterDelay());
    }

    IEnumerator SpawnObjectAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Spawn the object if no object has been spawned yet
        if (lastSpawnedObject == null)
        {
            SpawnObject();
        }

    }


    void SpawnObject()
    {
        // Determine the index of the object to spawn
        int index = isRandomize ? Random.Range(0, CustomersToSpawn.Count) : 0;

        // Check if there are objects in the list
        if (CustomersToSpawn.Count > 0)
        {
            // Instantiate the object at the current position and rotation of this object
            lastSpawnedObject = Instantiate(CustomersToSpawn[index], transform.position, CustomersToSpawn[index].transform.rotation);

            Debug.Log("Customer Spawned!");


            // Start a coroutine to destroy the object after 3 seconds (optional)
            // StartCoroutine(DestroyAfterDelay(lastSpawnedObject, 3f));
        }
    }

    //// Optional: Coroutine to destroy the object after a delay
    //IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    Destroy(obj);
    //}
}














    ////when clicked down (test)
    //private void OnMouseDown()
    //{
    //    // Only spawn an object if there isn't already a spawned object
    //    if (lastSpawnedObject == null)
    //    {
    //        SpawnObject();
    //    }
    //}

    //void SpawnObject()
    //{
    //    int index = isRandomize ? Random.Range(0, CustomersToSpawn.Count) : 0;

    //    if (CustomersToSpawn.Count > 0)
    //    {
    //        // Instantiate the object at the current position and rotation of this object
    //        lastSpawnedObject = Instantiate(CustomersToSpawn[index], transform.position, CustomersToSpawn[index].transform.rotation);

    //        Debug.Log("Customer Spawned!");

    //        // Start a coroutine to destroy the object after 1 second
    //        // this one can after all done with the items then destroy itself
    //        //StartCoroutine(DestroyAfterDelay(lastSpawnedObject, 3f));
    //    }
    //}

    ////// Coroutine to destroy the object after a delay
    /////
    ////IEnumerator DestroyAfterDelay(GameObject spawnedObject, float delay)
    ////{
    ////    // Wait for the specified amount of time
    ////    yield return new WaitForSeconds(delay);

    ////    // Destroy the spawned object after the delay
    ////    Destroy(spawnedObject);

    ////    // Allow the user to click again after the object is destroyed
    ////    lastSpawnedObject = null;
    ////}

   