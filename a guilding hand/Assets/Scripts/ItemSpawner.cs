using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite[] Sprite_Pic;
    public Vector3[] Sprite_Scale;

    public void UseSprite(int id) {
        GetComponent<SpriteRenderer>().sprite = Sprite_Pic[id];
        this.transform.localScale = Sprite_Scale[id];
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}

