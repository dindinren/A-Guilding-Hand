using UnityEngine;
using UnityEngine.UI;

public class testscript : MonoBehaviour
{
    
    public GameObject QuestForm;
    public GameObject Item;

    public AdvenInfoVariables AdvenInfo;
    public CustomerSpawner spawner;

    public CusName AdvenName;

    public Text testText1;
    public Text testText2;

    private void OnMouseDown()
    {
        Debug.Log("item clicked!");

        if (GameObject.FindGameObjectWithTag("Item"))
        {
            Destroy(gameObject);
        }

        //find tags
        var obj = GameObject.FindGameObjectsWithTag("QuestForm")[0];
        var obj2 = GameObject.FindGameObjectWithTag("QuestItem");
        var obj3 = GameObject.FindGameObjectWithTag("AdventureInfo");

        //pls be noted the DragDrop2D class is the StampDragging Script : Im so sorry for messing it up :((
        var correctStamp = GameObject.FindGameObjectWithTag("correct").GetComponent<DragDrop2D>();
        var incorrectStamp = GameObject.FindGameObjectWithTag("incorrect").GetComponent<DragDrop2D>();


        //spawn the 3 items on the righr
        Instantiate(QuestForm, obj.transform);
        Instantiate(Item, obj2.transform);
        AdvenInfoVariables advenInfo = Instantiate(AdvenInfo, obj3.transform);

        //spawn the text
        AdvenName.ChooseName();
        Debug.Log("Choose Name");

        //this is refering to the customerspawner class because the code is so spagethhi i cant spell sorry
        advenInfo.customerPic = spawner;
        
        //refering to the stampDragging class so that the stamps can call to this class
        correctStamp.adveninfovar = advenInfo;
        incorrectStamp.adveninfovar = advenInfo;

    }

    //since the item is a prefab = does not exist in the scene, the script can't call from said classes
    //this is to find the object and get their components so the code can reference from them
    public void Initialise()
    {
        //finding the text
        testText1 = GameObject.Find("NameText1").GetComponent<Text>();
        testText2 = GameObject.Find("NameText2").GetComponent<Text>();
        //finding the canvas
        AdvenName = GameObject.Find("Canvas").GetComponent<CusName>();
    }
}
