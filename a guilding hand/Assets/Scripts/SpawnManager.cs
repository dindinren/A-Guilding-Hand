using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public ItemSpawner Target;
    public ItemSpawner TargetpH;
    public ItemSpawner damagedTarget;

    private int targetID;
    private int targetpHID;
    private int damagedTargetID;
    private int fakeTargetpHID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetID = Random.Range(0, 2); //increase this number when targets increase
        Target.UseSprite(targetID);
        if (targetID == 0 || targetID == 1) // specifc numbers for this.
        {
            fakeTargetpHID = Random.Range(0, 1);
            TargetpH.UseSprite(fakeTargetpHID);
        }
        if (targetID == 2 || targetID == 3) // specifc numbers for this.
        {
            fakeTargetpHID = Random.Range(2, 3);
            TargetpH.UseSprite(fakeTargetpHID);
        }


        if (targetID == 0)
        {
            damagedTargetID = Random.Range(0, 2);
        } 
        
        /*else if(targetID == 1) 
        {
        }*/       
        
        
        else
        {
            damagedTargetID = Random.Range(2, 4);
        }
        damagedTarget.UseSprite(damagedTargetID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Result()
    {
        if (damagedTargetID % 2 != 0)
        {
            return false;
        }
        return true;
    }
}
