using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerSpawner : MonoBehaviour
{
    // List of customers to spawn
    public List<GameObject> CustomersToSpawn = new List<GameObject>();

    public int index; // Index is still used to select the customer prefab from the list

    // Time for the items to spawn
    public float itemstimetospawn;
    public float currenttimetospawn;

    //timer to spawn
    public float delay = 1;

    // Flag to randomize the object selection
    public bool isRandomize;

    // Reference to the last spawned object
    public GameObject lastSpawnedObject;

    // calling the ItemSpawn class to be used so that it can be respawned after the players stamp the Quest Form     
    public ItemSpawn itemspawn;

    //animation curve
    public AnimationCurve curve;

    public Collissionchangescript ccs;
    public pHColissionChange phccs;
    public SpawnManager spawnManager;

    AudioManager_MainArea audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_MainArea>();
        // Debug Log for AudioManager reference
        Debug.Log("CustomerSpawner Awake: AudioManager found? " + (audioManager != null ? "Yes!" : "No, it's null! (Check if AudioManager_MainArea exists and has tag 'AudioManager')"));
    }
    void Start()
    {

        spawnManager = Object.FindAnyObjectByType<SpawnManager>();

        // Start the coroutine to spawn the object after the delay
        StartCoroutine(SpawnObjectAfterDelay());

    }


    //wait a few seconds for the object to spawn
    IEnumerator SpawnObjectAfterDelay()
    {

        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        spawnManager.StartTrueFalse();

        // Spawn the object if no object has been spawned yet
        if (lastSpawnedObject == null)
        {
            SpawnObject(); // Ensure SpawnObject is called to set 'lastSpawnedObject' and its tag
        }


        //animation for customer to move toward  
        float elapsed = 0f;
        float duration = 1f;
        GameObject respawn = GameObject.FindGameObjectWithTag("Respawn");
        Vector2 endPos = respawn.transform.position;
        Vector2 startPos = lastSpawnedObject.transform.position;

        // --- Debug Log for actual customer tag ---
        if (lastSpawnedObject != null)
        {
            string customerActualTag = lastSpawnedObject.tag;
            Debug.Log($"CustomerSpawner: Spawning Customer. Its actual Tag is: '{customerActualTag}'");
            audioManager.PlayCustomerFootstepSFX(customerActualTag);
        }
        else
        {
            Debug.LogError("CustomerSpawner: lastSpawnedObject is null on arrival animation. Check if customer prefab is assigned to CustomersToSpawn list.");
        }
        // ---

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float ease = curve.Evaluate(t);

            lastSpawnedObject.transform.position = Vector2.Lerp(startPos, endPos, ease);

            elapsed += Time.deltaTime;
            yield return null;
        }
        Debug.Log("YOU MOVE NOW!");

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

        float elapsed = 0f;
        float duration = 1f;
        GameObject respawn = GameObject.FindGameObjectWithTag("Respawn2");
        Vector2 endPos = respawn.transform.position;
        Vector2 startPos = lastSpawnedObject.transform.position;

        // --- Debug Log for actual customer tag ---
        if (lastSpawnedObject != null)
        {
            string customerActualTag = lastSpawnedObject.tag;
            Debug.Log($"CustomerSpawner: Returning Customer. Its actual Tag is: '{customerActualTag}'");
            audioManager.PlayCustomerFootstepSFX(customerActualTag);
        }
        else
        {
            Debug.LogError("CustomerSpawner: lastSpawnedObject is null on return animation. Check if customer prefab is assigned to CustomersToSpawn list.");
        }
        // ---

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float ease = curve.Evaluate(t);

            lastSpawnedObject.transform.position = Vector2.Lerp(startPos, endPos, ease);

            elapsed += Time.deltaTime;
            yield return null;
        }
        Debug.Log("the customer has gone back");

        yield return new WaitForSeconds(delay = 1f);

        Destroy(lastSpawnedObject);
        Debug.Log("Customer destroyed!");

        itemspawn.itemSpawner();
        StartCoroutine(SpawnObjectAfterDelay());

        if (ccs != null)
        {
            ccs.Clear();
        }

        if (phccs != null)
        {
            phccs.Clear();
        }
    }

    public void SpawnObject()
    {
        index = isRandomize ? Random.Range(0, CustomersToSpawn.Count) : CustomersToSpawn.Count - 1;

        if (CustomersToSpawn.Count > 0)
        {
            lastSpawnedObject = Instantiate(CustomersToSpawn[index], transform.position, CustomersToSpawn[index].transform.rotation);
            Debug.Log("Customer " + CustomersToSpawn[index].name + " Spawned!");
        }
    }
}
