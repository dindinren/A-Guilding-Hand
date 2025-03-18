using UnityEngine;
using System.Collections;

public class ItemSpawn : MonoBehaviour
{
    public GameObject SpawnItem; // The item to spawn

    public CustomerSpawner customerPic;

    private GameObject lastSpawnedItem; // Reference to the last spawned item
    private bool canSpawn = true; // Flag to control if the item can be spawned

    AudioManager_MainArea audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_MainArea>();
    }
    void Start()
    {
        // Start the coroutine to spawn the item after 2 seconds
        StartCoroutine(SpawnAfterDelay(2f));
    }

    public void itemSpawner()
    {
        canSpawn = true;
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

            ///Set item to active (ASC)
            //SpawnItem.SetActive(true);

            testscript script = lastSpawnedItem.GetComponent<testscript>();
            if(script != null)
            {
                //script.Initialise();
                script.spawner = customerPic;
            }
            // Disable further spawning
            canSpawn = false;

            Debug.Log("Item object spawned!");

            //SFX for spawning the item
            audioManager.PlaySFX(audioManager.ItemSFX);
        }
    }
}
