using UnityEngine;
using System.Collections;
// using UnityEditor.Purchasing;

public class Collissionchangescript : MonoBehaviour
{
    public Sprite newSprite;
    public Sprite clearSprite;


    private void Start()
    {

    }

    
    public bool hasTouchedObject = false;
    public void TouchedObject()
    {
       hasTouchedObject = true;
    }
    
    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided with: " + other.gameObject.name); // Debugging line
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name); // Debugging line

        //Check if colliding with object or with pH?
        if (other.tag == "Target")
        {
            TouchedObject();
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }


    }

    public void Clear()
    {
        GetComponent<SpriteRenderer>().sprite = clearSprite;
    }
}

