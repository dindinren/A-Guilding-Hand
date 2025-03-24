using UnityEngine;
using System.Collections;
// using UnityEditor.Purchasing;

public class Collissionchangescript : MonoBehaviour
{
    public Sprite newSprite;
    public Sprite clearSprite;

    [SerializeField] private SpriteRenderer renderInParent;

    private void Awake()
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
            renderInParent.sprite = newSprite;
        }


    }

    public void Clear()
    {
        renderInParent.sprite = clearSprite;
    }
}

