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
    public BoxCollider2D BoxCollider2D;

    public bool TrueFalse()
    {
        
        trueorfalseID = Random.Range(0, 2);
        Debug.Log(trueorfalseID);
        if (trueorfalseID == 0)
        {

            Debug.Log("Results are true");
            return true;
 
        }
        else
        {
            Debug.Log("Results are false");
            return false;

        }
    }
        
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Collided with: " + other.gameObject.name); // Debugging line

        if (TrueFalse() == true)
        {
            if (spawnManagerObject.superInitialTargetID == 0)
            {
                // Debug.Log("Results are true");
                GetComponent<SpriteRenderer>().sprite = threePH;
                BoxCollider2D.enabled = false;

            }

            if (spawnManagerObject.superInitialTargetID == 1)
            {
                // Debug.Log("Results are true");
                GetComponent<SpriteRenderer>().sprite = sixPH;
                BoxCollider2D.enabled = false;

            }
            if (spawnManagerObject.superInitialTargetID == 2)
            {
                // Debug.Log("Results are true");
                GetComponent<SpriteRenderer>().sprite = onePH;
                BoxCollider2D.enabled = false;

            }
            if (spawnManagerObject.superInitialTargetID == 3)
            {
                // Debug.Log("Results are true");
                GetComponent<SpriteRenderer>().sprite = fourPH;
                BoxCollider2D.enabled = false;

            }
        }
        

        if (TrueFalse() == false)
        {
            if (spawnManagerObject.superInitialTargetID == 0)
            {
                // Debug.Log("Results are false");
                GetComponent<SpriteRenderer>().sprite = sixPH;
                BoxCollider2D.enabled = false;
            }

            if (spawnManagerObject.superInitialTargetID == 1)
            {
                // Debug.Log("Results are false");
                GetComponent<SpriteRenderer>().sprite = threePH;
                BoxCollider2D.enabled = false;

            }
            if (spawnManagerObject.superInitialTargetID == 2)
            {
                // Debug.Log("Results are false");
                GetComponent<SpriteRenderer>().sprite = fivePH;
                BoxCollider2D.enabled = false;

            }
            if (spawnManagerObject.superInitialTargetID == 3)
            {
                // Debug.Log("Results are false");
                GetComponent<SpriteRenderer>().sprite = sevenPH;
                BoxCollider2D.enabled = false;

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
        BoxCollider2D.enabled = true;
    }


}
