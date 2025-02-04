using UnityEngine;
using System.Collections;

public class ItemSpawn : MonoBehaviour
{
    public GameObject SpawnItem; // The item to spawn

    private GameObject lastSpawnedItem; // Reference to the last spawned item
    private bool canSpawn = true; // Flag to control if the item can be spawned

    void Start()
    {
        // Start the coroutine to spawn the item after 2 seconds
        StartCoroutine(SpawnAfterDelay(2f));
    }

    IEnumerator SpawnAfterDelay(float delay)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(delay);

        // Check if spawning is allowed
        if (canSpawn)
        {
            // Spawn the item and set its position
            lastSpawnedItem = Instantiate(SpawnItem, transform.position, transform.rotation);
            lastSpawnedItem.transform.position = new Vector3(lastSpawnedItem.transform.position.x, lastSpawnedItem.transform.position.y, -5);

            // Disable further spawning
            canSpawn = false;

            Debug.Log("Item object spawned!");
        }
    }

    void Update()
    {
        // No need for logic in Update for this use case
    }

}
