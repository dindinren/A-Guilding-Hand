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

    private void FixedUpdate()
    {
        //Debug.Log(Input.mousePosition);
        // Cast a ray starting from the object's position in the right direction
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // GetComponent<Collider>().
    }

    private void OnMouseDown()
    {
        Debug.Log("item clicked!");
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
