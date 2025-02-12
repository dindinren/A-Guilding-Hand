using UnityEngine;
using UnityEngine.Rendering;

public class SpawnManager : MonoBehaviour
{
    
    public ItemSpawner initialTarget;
    public ItemSpawner Target;
    public ItemSpawner damagedTarget;
    public ItemSpawner targetpH;


    private int initialTargetID;
    private int targetID;
    private int damagedTargetID;
    private int targetpHID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        initialTargetID = Random.Range(0, 3);
        initialTarget.UseSprite(initialTargetID);
        
        if (initialTargetID == 0)
        {
            targetID = 0;
            Target.UseSprite(targetID);
            if (targetID == 0)
            {
                damagedTargetID = Random.Range(0, 2);
                damagedTarget.UseSprite(damagedTargetID);
            }

            if (targetID == 0)
            {
                targetpHID = Random.Range(0, 2);
                targetpH.UseSprite(targetpHID);

            }
        }

        else if (initialTargetID == 1)
        {
            targetID = 1;
            Target.UseSprite(targetID);
            if (targetID == 1)
            {
                damagedTargetID = Random.Range(2, 4);
                damagedTarget.UseSprite(damagedTargetID);
            }

            if (targetID == 1)
            {
                targetpHID = Random.Range(2, 4);
                targetpH.UseSprite(targetpHID);
            }
        }


        else if (initialTargetID == 2)
        {
            targetID = 2;
            Target.UseSprite(targetID);
            if (targetID == 2)
            {
                damagedTargetID = Random.Range(4, 6);
                damagedTarget.UseSprite(damagedTargetID);
            }

            if (targetID == 2)
            {
                targetpHID = Random.Range(4, 6);
                targetpH.UseSprite(targetpHID);
            }
        }

        else
        {
            targetID = 3;
            Target.UseSprite(targetID);
            if (targetID == 3)
            {
                damagedTargetID = Random.Range(6, 8);
                damagedTarget.UseSprite(damagedTargetID);
            }

            if (targetID == 3)
            {
                targetpHID = Random.Range(6, 8);
                targetpH.UseSprite(targetpHID);
            }
        }
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

    public bool ResultpH()
    {
        if (targetpHID % 2 != 0)
        {
            return false;
        }
        return true;
    }

    public bool finalResult()
    {
        if (Result() == true && ResultpH () == true)
        {
            return true;
        }
        return false;
    }
}
