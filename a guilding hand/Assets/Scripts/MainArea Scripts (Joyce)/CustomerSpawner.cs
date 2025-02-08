using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerSpawner : MonoBehaviour
{
    // List of customers to spawn
    public List<GameObject> CustomersToSpawn = new List<GameObject>();
    
    public int index;

    // Time for the items to spawn
    public float itemstimetospawn;
    public float currenttimetospawn;

    //timer to spawn
    public float delay = 1f;

    // Flag to randomize the object selection
    public bool isRandomize;

    // Reference to the last spawned object
    public GameObject lastSpawnedObject;

    // calling the ItemSpawn class to be used so that it can be respawned after the players stamp the Quest Form    
    public ItemSpawn itemspawn;


    void Start()
    {
        // Start the coroutine to spawn the object after the delay
        StartCoroutine(SpawnObjectAfterDelay());
    }


    //wait a few seconds for the object to spawn
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

    //to allow the StampDragging Script to call it
    public void CustomerDelete()
    {
        //at most 3 seconds to not immediately despawn the customer along with the 3 items
        StartCoroutine(GetReadytoDelete(3f)); 
    }

    //the customer will despawn and then respawn after a while
    IEnumerator GetReadytoDelete(float delay)
    {
        yield return new WaitForSeconds(delay);

        //destroy the customer
        Destroy(lastSpawnedObject);
        Debug.Log("Customer destroyed!");


        yield return new WaitForSeconds(delay);

        //respawn the customer and item for the next loop
        SpawnObject();
        itemspawn.itemSpawner();
    }

   
    //Customer Spawning
    public void SpawnObject()
    {
        // check if its randomise if yes select from the range of 0 to the end of the list if no just spawn the last customer from the list
        index = isRandomize ? Random.Range(0, CustomersToSpawn.Count) : CustomersToSpawn.Count-1;

        // Check if there are objects in the list
        if (CustomersToSpawn.Count > 0)
        {
            // Instantiate the object at the current position and rotation of this object
            lastSpawnedObject = Instantiate(CustomersToSpawn[index], transform.position, CustomersToSpawn[index].transform.rotation);
            Debug.Log("Customer {0} Spawned!" +CustomersToSpawn[index]);
        }
    }

}

   