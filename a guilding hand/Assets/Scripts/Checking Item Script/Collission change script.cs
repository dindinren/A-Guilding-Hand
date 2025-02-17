using UnityEngine;
using System.Collections;

public class Collissionchangescript : MonoBehaviour
{
    public Sprite newSprite;
    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided with: " + other.gameObject.name); // Debugging line
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name); // Debugging line
        GetComponent<SpriteRenderer>().sprite = newSprite;

    }
}

