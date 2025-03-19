using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnManager : MonoBehaviour
{

    public ItemSpawner superInitialTarget;
    public ItemSpawner initialTarget;
    public ItemSpawner Target;
    public ItemSpawner damagedTarget;
    public ItemSpawner targetpH;


    private bool predeterminedTrueFalse;
    public bool hasChanged = false;
    private int realorfakeID;

    public int superInitialTargetID;
    private int initialTargetID;
    private int targetID;
    private int damagedTargetID;
    public int targetpHID;
    public pHColissionChange pHColissionChange;
    private bool storedpHresult;


    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool StartTrueFalse()
    {
        if (!hasChanged)
        {
            realorfakeID = Random.Range(0, 2);
            if (realorfakeID == 0)
            {
                Debug.Log("Customer Will Be True");
                predeterminedTrueFalse = true;

            }
            else
            {
                Debug.Log("Customer Might Be False");
                predeterminedTrueFalse = false;
            }
            hasChanged = true;
            return predeterminedTrueFalse;
        }
        else
        {
            return predeterminedTrueFalse;
        }
    }

    public bool Result()
    {
        if (predeterminedTrueFalse == true)
        {
            return true;
        }
        else
        {
            if (damagedTargetID % 2 != 0)
            {
                return false;
            }
            return true;
        }

    }

    public bool ResultpH()
    {
        if (predeterminedTrueFalse == true)
        {
            return true;
        }
        else
        {
            return pHColissionChange.TrueFalse();
        }

    }

    public bool finalResult()
    {
        if (Result() == true && ResultpH () == true)
        {
            return true;
        }
        return false;
    }

    public void SetUpQuestItem()
    {
        superInitialTargetID = Random.Range(0, 4);
        superInitialTarget.UseSprite(superInitialTargetID);
        initialTargetID = superInitialTargetID;
        initialTarget.UseSprite(initialTargetID);


        if (initialTargetID == 0)
        {
            targetID = 0;
            Target.UseSprite(targetID);
            if (targetID == 0)
            {
                damagedTargetID = Random.Range(0, 2);
                if (predeterminedTrueFalse == true)
                {
                    damagedTarget.UseSprite(damagedTargetID = 0);
                }
                else
                {
                    damagedTarget.UseSprite(damagedTargetID);
                }
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
                if (predeterminedTrueFalse == true)
                {
                    damagedTarget.UseSprite(damagedTargetID = 2);
                }
                else
                {
                    damagedTarget.UseSprite(damagedTargetID);
                }
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
                if (predeterminedTrueFalse == true)
                {
                    damagedTarget.UseSprite(damagedTargetID = 4);
                }
                else
                {
                    damagedTarget.UseSprite(damagedTargetID);
                }
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
                if (predeterminedTrueFalse == true)
                {
                    damagedTarget.UseSprite(damagedTargetID = 6);
                }
                else
                {
                    damagedTarget.UseSprite(damagedTargetID);
                }
                targetpHID = Random.Range(6, 8);
                targetpH.UseSprite(targetpHID);
            }

        }
    }
}
