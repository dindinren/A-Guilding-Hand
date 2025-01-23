using UnityEngine;
using System.Collections;

public class ItemSpawn : MonoBehaviour
{
    public GameObject SpawnItem;

    private GameObject lastSpawnedItem;
    private bool canSpawn = true; // Flag to control if the item can be spawned

    IEnumerator SpawnAfterDelay(float delay)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(delay);

        // Spawn the item and set the flag to false to prevent further spawns
        var obj = Instantiate(SpawnItem, transform.position, transform.rotation);
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, -5);
        lastSpawnedItem = SpawnItem;  // Assign the spawned item to prevent further spawns
        canSpawn = false;  // Disable further spawning until reset
        Debug.Log("Item Spawned!");
    }

    void Start()
    {
        // You can add logic here to reset the flag if needed (for example, after some time or event)
    }

    void Update()
    {
        // Check for mouse click only if spawning is allowed
        if (Input.GetMouseButtonDown(0) && canSpawn)
        {
            StartCoroutine(SpawnAfterDelay(2f));
        }
    }

    private void OnMouseDown()
    {
        // Only spawn an object if there isn't already a spawned object
        Debug.Log("ItemSpawn MouseDown");
    }
    //// You can create a method to reset the spawn process if needed.
    //// For example, if you want to reset the spawn flag after some time:
    //public void ResetSpawn()
    //{
    //    canSpawn = true;
    //    lastSpawnedItem = null;
    //}
}
