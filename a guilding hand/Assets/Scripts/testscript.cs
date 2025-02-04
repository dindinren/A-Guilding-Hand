using UnityEngine;

public class testscript : MonoBehaviour
{
    public GameObject QuestForm;
    public GameObject AdvenInfo;
    public GameObject Item;

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
        
        Instantiate(QuestForm, obj.transform);
        Instantiate(AdvenInfo, obj2.transform);
        Instantiate(Item, obj3.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
