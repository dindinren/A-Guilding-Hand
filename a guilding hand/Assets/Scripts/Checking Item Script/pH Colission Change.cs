using UnityEngine;
using UnityEngine.Rendering;

public class pHColissionChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Sprite noPH;
    [SerializeField] private Sprite onePH;
    [SerializeField] private Sprite twoPH;
    [SerializeField] private Sprite threePH;
    [SerializeField] private Sprite fourPH;
    [SerializeField] private Sprite fivePH;
    [SerializeField] private Sprite sixPH;
    [SerializeField] private Sprite sevenPH;

    [SerializeField] private SpawnManager spawnManagerObject;

    public Sprite clearSprite;
    public Collissionchangescript Collissionchangescript;
    public int trueorfalseID;
    public Collider2D Collider2D;

    public bool TrueFalse()
    {
        trueorfalseID = Random.Range(0, 2);
        if (trueorfalseID == 0)
        {
            return true;
        }
        return false;
    }
        
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Collided with: " + other.gameObject.name); // Debugging line

        if (TrueFalse() == true)
        {
            if (spawnManagerObject.superInitialTargetID == 0)
            {
                Debug.Log("Results are true");
                GetComponent<SpriteRenderer>().sprite = threePH;

            }

            if (spawnManagerObject.superInitialTargetID == 1)
            {
                Debug.Log("Results are true");
                GetComponent<SpriteRenderer>().sprite = sixPH;

            }
            if (spawnManagerObject.superInitialTargetID == 2)
            {
                Debug.Log("Results are true");
                GetComponent<SpriteRenderer>().sprite = onePH;

            }
            if (spawnManagerObject.superInitialTargetID == 3)
            {
                Debug.Log("Results are true");
                GetComponent<SpriteRenderer>().sprite = fourPH;

            }
        }
        

        if (TrueFalse() == false)
        {
            if (spawnManagerObject.superInitialTargetID == 0)
            {
                Debug.Log("Results are false");
                GetComponent<SpriteRenderer>().sprite = sixPH;
            }

            if (spawnManagerObject.superInitialTargetID == 1)
            {
                Debug.Log("Results are false");
                GetComponent<SpriteRenderer>().sprite = threePH;

            }
            if (spawnManagerObject.superInitialTargetID == 2)
            {
                Debug.Log("Results are false");
                GetComponent<SpriteRenderer>().sprite = fivePH;

            }
            if (spawnManagerObject.superInitialTargetID == 3)
            {
                Debug.Log("Results are false");
                GetComponent<SpriteRenderer>().sprite = sevenPH;

            }
        }



        if (Collissionchangescript.hasTouchedObject == false)
        {
            GetComponent<SpriteRenderer>().sprite = noPH;
        }

    }

    public void Clear()
    {
        GetComponent<SpriteRenderer>().sprite = clearSprite;
    }


}
