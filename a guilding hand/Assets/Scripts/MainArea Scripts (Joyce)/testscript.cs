using UnityEngine;

public class testscript : MonoBehaviour
{
    
    public GameObject QuestForm;
    public GameObject Item;

    public AdvenInfoVariables AdvenInfo;
    public CustomerSpawner spawner;

    private void OnMouseDown()
    {
        Debug.Log("item clicked!");

        if (GameObject.FindGameObjectWithTag("Item"))
        {
            Destroy(gameObject);
        }

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

        //this is refering to the customerspawner class because the code is so spagethhi i cant spell sorry
        advenInfo.customerPic = spawner;
        
        //refering to the stampDragging class so that the stamps can call to this class
        correctStamp.adveninfovar = advenInfo;
        incorrectStamp.adveninfovar = advenInfo;

    }
}
