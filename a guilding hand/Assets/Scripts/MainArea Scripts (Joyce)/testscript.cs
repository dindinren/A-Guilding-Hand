using UnityEngine;
using TMPro;

public class testscript : MonoBehaviour
{
    public GameObject QuestForm;
    public GameObject Item;
    public GameObject questItem;
    public GameObject questItemSpawnManager;

    public AdvenInfoVariables AdvenInfo;
    public CustomerSpawner spawner; // Reference to your CustomerSpawner

    public CusName AdvenName;

    private GameObject questFormInstance;
    private AdvenInfoVariables advenInfo;

    public TextMeshPro testText1;
    public TextMeshPro testText2;

    AudioManager_MainArea audioManager;

    private void Awake()
    {
        GameObject audioManagerGO = GameObject.FindGameObjectWithTag("AudioManager");
        if (audioManagerGO != null)
        {
            audioManager = audioManagerGO.GetComponent<AudioManager_MainArea>();
            if (audioManager == null)
            {
                Debug.LogError("testscript: AudioManager_MainArea component not found on GameObject with tag 'AudioManager'.", audioManagerGO);
            }
        }
        else
        {
            Debug.LogError("testscript: GameObject with tag 'AudioManager' not found in the scene. SFX might not play.");
        }
    }

    private void OnMouseDown()
    {
        if (!PauseMenu.instance.isPause)
        {
            Debug.Log("Item clicked!");

            // --- SFX Playback Logic ---
            if (audioManager != null)
            {
                // 1. Play the general ItemSFXClick first
                if (audioManager.ItemSFXClick != null)
                {
                    audioManager.PlaySFX(audioManager.ItemSFXClick);
                    Debug.Log("Playing general ItemSFXClick.");
                }
                else
                {
                    Debug.LogWarning("AudioManager.ItemSFXClick is not assigned. Cannot play general item click SFX.");
                }

                // 2. Then, play the customer-specific item interaction SFX
                string activeCustomerTag = string.Empty;

                if (spawner != null)
                {
                    activeCustomerTag = spawner.GetCurrentActiveCustomerTag(); // Get the tag from CustomerSpawner
                }
                else
                {
                    Debug.LogError("testscript: CustomerSpawner reference is null. Please assign it in the Inspector.");
                }

                if (!string.IsNullOrEmpty(activeCustomerTag))
                {
                    audioManager.PlayCustomerItemInteractionSFX(activeCustomerTag);
                    Debug.Log($"Playing customer-specific item interaction SFX for: {activeCustomerTag}");
                }
                else
                {
                    Debug.LogWarning("testscript: Active customer tag is empty. Cannot play customer-specific item interaction SFX.");
                }
            }
            else
            {
                Debug.LogWarning("testscript: AudioManager not found or not assigned. Cannot play any item interaction SFX.");
            }
            // --- End SFX Playback Logic ---

            // Original item destruction logic
            if (gameObject.CompareTag("Item"))
            {
                Destroy(gameObject);
            }

            //finding the canvas
            AdvenName = GameObject.Find("Canvas").GetComponent<CusName>();

            //find tags
            var obj = GameObject.FindGameObjectsWithTag("QuestForm")[0];
            var obj2 = GameObject.FindGameObjectWithTag("QuestItem");
            var obj3 = GameObject.FindGameObjectWithTag("AdventureInfo");
            questItemSpawnManager = GameObject.FindGameObjectWithTag("SpawnManager");

            var correctStamp = GameObject.FindGameObjectWithTag("correct").GetComponent<DragDrop2D>();
            var incorrectStamp = GameObject.FindGameObjectWithTag("incorrect").GetComponent<DragDrop2D>();

            //spawn the 3 items on the right
            questFormInstance = Instantiate(QuestForm, obj.transform);
            Instantiate(Item, obj2.transform);
            questItemSpawnManager.GetComponent<SpawnManager>().SetUpQuestItem();
            Instantiate(questItem, obj2.transform);

            advenInfo = Instantiate(AdvenInfo, obj3.transform);

            //spawn the text
            Initialise();
            AdvenName.setText(testText1);
            AdvenName.setText2(testText2);
            AdvenName.ChooseName();
            Debug.Log("Choose Name");

            advenInfo.customerPic = spawner;

            correctStamp.adveninfovar = advenInfo;
            incorrectStamp.adveninfovar = advenInfo;
        }
    }

    public void Initialise()
    {
        testText1 = questFormInstance.GetComponentInChildren<TextMeshPro>();
        testText2 = advenInfo.GetComponentInChildren<TextMeshPro>();
    }
}