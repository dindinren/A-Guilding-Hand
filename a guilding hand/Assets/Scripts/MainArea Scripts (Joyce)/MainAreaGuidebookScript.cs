using System.Runtime.CompilerServices;
using UnityEngine;

public class MainAreaGuidebookScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private Sprite guidebookMinimized, guidebookEnlarged;
    private bool isBig;
    private SpriteRenderer rend;
    private BoxCollider2D newCollider;
    
    
    void Start()

    {
        newCollider =gameObject.AddComponent<BoxCollider2D>();
        newCollider.isTrigger = true;
        isBig = false;
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        rend.sprite = isBig ? guidebookMinimized : guidebookEnlarged; 
        isBig = !isBig;
        Destroy(newCollider);
        newCollider = gameObject.AddComponent<BoxCollider2D>();
        newCollider.isTrigger = true;

    }
}
