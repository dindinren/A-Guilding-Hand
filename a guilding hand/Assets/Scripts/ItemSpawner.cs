using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private int rand;
    public Sprite[] Sprite_Pic;

    public void UseSprite(int id) {
        GetComponent<SpriteRenderer>().sprite = Sprite_Pic[id];
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}

