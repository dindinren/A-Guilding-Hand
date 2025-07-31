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
    public float delay = 1;

    // Flag to randomize the object selection
    public bool isRandomize;

    // Reference to the last spawned object (the currently active customer)
    public GameObject lastSpawnedObject;

    public ItemSpawn itemspawn;

    public AnimationCurve curve;

    public Collissionchangescript ccs;
    public pHColissionChange phccs;
    public SpawnManager spawnManager;

    AudioManager_MainArea audioManager;

    // NEW: Public method to get the current active customer's tag
    public string GetCurrentActiveCustomerTag()
    {
        if (lastSpawnedObject != null)
        {
            return lastSpawnedObject.tag;
        }
        return string.Empty; // Return empty string if no customer is active
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_MainArea>();
        Debug.Log("CustomerSpawner Awake: AudioManager found? " + (audioManager != null ? "Yes!" : "No, it's null! (Check if AudioManager_MainArea exists and has tag 'AudioManager')"));
    }

    void Start()
    {
        spawnManager = Object.FindAnyObjectByType<SpawnManager>();
        StartCoroutine(SpawnObjectAfterDelay());
    }

    IEnumerator SpawnObjectAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        spawnManager.StartTrueFalse();

        if (lastSpawnedObject == null)
        {
            SpawnObject();
        }

        float elapsed = 0f;
        float duration = 1f;
        GameObject respawn = GameObject.FindGameObjectWithTag("Respawn");
        Vector2 endPos = respawn.transform.position;
        Vector2 startPos = lastSpawnedObject.transform.position;

        if (lastSpawnedObject != null)
        {
            string customerActualTag = lastSpawnedObject.tag;
            Debug.Log($"CustomerSpawner: Spawning Customer. Its actual Tag is: '{customerActualTag}'");
            if (audioManager != null)
            {
                audioManager.PlayCustomerFootstepSFX(customerActualTag);
            }
            else
            {
                Debug.LogWarning("CustomerSpawner: AudioManager is null. Cannot play footstep SFX.");
            }
        }
        else
        {
            Debug.LogError("CustomerSpawner: lastSpawnedObject is null on arrival animation. Check if customer prefab is assigned to CustomersToSpawn list.");
        }

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

    public void CustomerDelete()
    {
        StartCoroutine(GetReadytoDelete(3f));
    }

    IEnumerator GetReadytoDelete(float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 1f;
        GameObject respawn = GameObject.FindGameObjectWithTag("Respawn2");
        Vector2 endPos = respawn.transform.position;
        Vector2 startPos = lastSpawnedObject.transform.position;

        if (lastSpawnedObject != null)
        {
            string customerActualTag = lastSpawnedObject.tag;
            Debug.Log($"CustomerSpawner: Returning Customer. Its actual Tag is: '{customerActualTag}'");
            if (audioManager != null)
            {
                audioManager.PlayCustomerFootstepSFX(customerActualTag);
            }
            else
            {
                Debug.LogWarning("CustomerSpawner: AudioManager is null. Cannot play footstep SFX.");
            }
        }
        else
        {
            Debug.LogError("CustomerSpawner: lastSpawnedObject is null on return animation. Check if customer prefab is assigned to CustomersToSpawn list.");
        }

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
