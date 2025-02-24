using UnityEngine;

public class pHColissionChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Sprite noPH;
    [SerializeField] private Sprite redPH;
    [SerializeField] private Sprite bluePH;
    [SerializeField] private SpawnManager spawnManagerObject;

    public Sprite clearSprite;

        
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.gameObject.name); // Debugging line
        if (spawnManagerObject.ResultpH() == false)
        {
            Debug.Log("Results are false");
            GetComponent<SpriteRenderer>().sprite = bluePH;
        }
        else
        {
            Debug.Log("Results are true");
            GetComponent<SpriteRenderer>().sprite = redPH;
        }

    }

    public void Clear()
    {
        GetComponent<SpriteRenderer>().sprite = clearSprite;
    }


}
