using UnityEngine;
using TMPro;

public class testscript : MonoBehaviour
{
    
    public GameObject QuestForm;
    public GameObject Item;
    public GameObject questItem;
    public GameObject questItemSpawnManager;

    public AdvenInfoVariables AdvenInfo;
    public CustomerSpawner spawner;

    public CusName AdvenName;

    private GameObject questFormInstance;
    private AdvenInfoVariables advenInfo;

    public TextMeshPro testText1;
    public TextMeshPro testText2;

    AudioManager_MainArea audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_MainArea>();
    }
    private void OnMouseDown()
    {
        //if the instance who has the address reference to the PauseMenu Script where isPause = false, 
        //it will run the code where the item spawn and buisiness as usual
        if(!PauseMenu.instance.isPause)
        {
            Debug.Log("item clicked!");

            if (GameObject.FindGameObjectWithTag("Item"))
            {
                Destroy(gameObject);

                audioManager.PlaySFX(audioManager.ItemSFXClick);
            }

            //finding the canvas
            AdvenName = GameObject.Find("Canvas").GetComponent<CusName>();

            //find tags
            var obj = GameObject.FindGameObjectsWithTag("QuestForm")[0];
            var obj2 = GameObject.FindGameObjectWithTag("QuestItem");
            var obj3 = GameObject.FindGameObjectWithTag("AdventureInfo");
            questItemSpawnManager = GameObject.FindGameObjectWithTag("SpawnManager");

            //pls be noted the DragDrop2D class is the StampDragging Script : Im so sorry for messing it up :((
            var correctStamp = GameObject.FindGameObjectWithTag("correct").GetComponent<DragDrop2D>();
            var incorrectStamp = GameObject.FindGameObjectWithTag("incorrect").GetComponent<DragDrop2D>();


            //spawn the 3 items on the righr
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

            //this is refering to the customerspawner class because the code is so spagethhi i cant spell sorry
            advenInfo.customerPic = spawner;

            //refering to the stampDragging class so that the stamps can call to this class
            correctStamp.adveninfovar = advenInfo;
            incorrectStamp.adveninfovar = advenInfo;

        }


        
    }

    //since the item is a prefab = does not exist in the scene, the script can't call from said classes
    //this is to find the object and get their components so the code can reference from them
    public void Initialise()
    {
        //finding the text
        testText1 = questFormInstance.GetComponentInChildren<TextMeshPro>();
        testText2 = advenInfo.GetComponentInChildren<TextMeshPro>();
    }
}
