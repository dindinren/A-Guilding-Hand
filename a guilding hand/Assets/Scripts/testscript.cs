using UnityEngine;

public class testscript : MonoBehaviour
{
    
    public GameObject QuestForm;
    public AdvenInfoVariables AdvenInfo;
    public GameObject Item;

    public CustomerSpawner spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnMouseDown()
    {
        Debug.Log("item clicked!");

        if (GameObject.FindGameObjectWithTag("Item"))
        {
            Destroy(gameObject);
        }

        //spawn the items on the right
        var obj = GameObject.FindGameObjectsWithTag("QuestForm")[0];
        var obj2 = GameObject.FindGameObjectWithTag("QuestItem");
        var obj3 = GameObject.FindGameObjectWithTag("AdventureInfo");

        //pls be noted the DragDrop2D class is the StampDragging Script : Im so sorry for messing it up :((
        var correctStamp = GameObject.FindGameObjectWithTag("correct").GetComponent<DragDrop2D>();
        var incorrectStamp = GameObject.FindGameObjectWithTag("incorrect").GetComponent<DragDrop2D>();


        Instantiate(QuestForm, obj.transform);
        Instantiate(Item, obj2.transform);
        AdvenInfoVariables advenInfo = Instantiate(AdvenInfo, obj3.transform);
        advenInfo.customerPic = spawner;
        
        correctStamp.adveninfovar = advenInfo;
        incorrectStamp.adveninfovar = advenInfo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
