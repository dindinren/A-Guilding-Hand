using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Reflection;

public class DragDrop2D : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;
    public string destinationTag = "DropArea";
    private Vector3 originalPosition; // Store the original position of the object

    public GameObject tick;
    public AnimationCurve temp;

    private bool returncheck;

    public CustomerSpawner customerspawner;
    public AdvenInfoVariables adveninfovar;

    public ScoreManager scoremanager;

    public CusName cusname;
    public SpawnManager spawnManager;



    //dun let the tick/cross be seen at first
    private void Start()
    {
        tick.SetActive(false);
    }

    
    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        originalPosition = transform.position; // Store the initial position
    }

    //if clicked
    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    //if dragged
    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    //if let go of the mouse
    void OnMouseUp()
    {
        //check the mouse position
        collider2d.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo;

        // Check if the object is dropped in the drop area
        if (hitInfo = Physics2D.Raycast(rayOrigin, rayDirection))
        {
            if (hitInfo.transform.CompareTag(destinationTag))
            {
                // Snap the object to the drop area
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);

       
                //CHECKER
                //TODO: implement the check with the checking item logic
                
                //Check if player dragged 'Green' Stamp
                if(gameObject.CompareTag("correct"))
                {
                    //If correct
                    //Check if name matches and pic matches
                    if(adveninfovar.isItTheSame == true && cusname.areTheNameSame == true && spawnManager.finalResult() == true)
                    {
                        scoremanager.AddPoints();
                    }
                    else
                    {
                        scoremanager.MinusPoints();
                    }
                }
                //Check if player dragged 'Red' Stamp
                else
                {
                    //If not correct
                    //if either of the name or the pic does not match
                    if (adveninfovar.isItTheSame == false || cusname.areTheNameSame == false || spawnManager.finalResult() == false)
                    {
                        scoremanager.AddPoints();//why add is because the player is right because they stamp with the incorrect and either of the things are not correct
                    }
                    else
                    {
                        scoremanager.MinusPoints();
                    }
                }


                // Destroy the items after 1 second after a while it will respawn and the whole loop starts over again
                StartCoroutine(DestroyAndRespawnAfterDelay(1f)); 
                Debug.Log("Object dropped in the drop area. It will be destroyed and respawned.");

                //then the customer goes bye bye
                customerspawner.CustomerDelete();
            }
            else
            {
                // Return to the original position if not dropped in the drop area
                returncheck = true;
                Debug.Log("Returned to original position.");
            }
        }
        else
        {
            // Return to the original position if no valid drop area is hit
            returncheck = true;
            Debug.Log("Returned to original position.");
        }

        //reenable the collider for people to drag the stamps again
        collider2d.enabled = true;
    }


    // After stamping, the items will get ready to despawn while the stamp goes back to its original position
    IEnumerator DestroyAndRespawnAfterDelay(float delay)
    {
        //Show the tick 
        tick.SetActive(true);

        //animation to go back
        float elapsed = 0f;
        float duration = 1f;
        Vector2 startPos = transform.position;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float ease = temp.Evaluate(t);
            transform.position = Vector2.Lerp(startPos, originalPosition, ease);

            elapsed += Time.deltaTime;
            yield return null;
        }
        
        // the items will get ready to destroy
        yield return new WaitForSeconds(delay);


        GameObject[] obj = GameObject.FindGameObjectsWithTag("QuestItemObject");
        foreach (GameObject ob in obj)
        {
            Destroy(ob);
        }
        GameObject[] obj2 = GameObject.FindGameObjectsWithTag("QuestFormObject");
        foreach (GameObject ob2 in obj2)
        {
            Destroy(ob2);
        }
        GameObject[] obj3 = GameObject.FindGameObjectsWithTag("AdventureFormObject");
        foreach (GameObject ob3 in obj3)
        {
            Destroy(ob3);
        }

        GameObject[] obj4 = GameObject.FindGameObjectsWithTag("QuestItemInitial");
        foreach (GameObject ob4 in obj4)
        {
            Destroy(ob4);
        }
        Debug.Log("Object destroyed!");

        //the tick/cross also go bye bye
        tick.SetActive(false);

        cusname.nameText.enabled = false;
        cusname.nameText2.enabled = false;

        //along with the adven info profile pic
        adveninfovar.PicIsDestroyed();
        Debug.Log("the pic will be destroyed");
    }

    private void FixedUpdate()
    {
        if (returncheck == true)
        {
            ReturnToOriginalPosition();
        }
    }

    //for the fixedupdate than anything | for the animation curve and make the stamp go back nicely
    void ReturnToOriginalPosition()
    {
        float elapsed = 0f;
        float duration = 1f;
        Vector2 startPos = transform.position;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float ease = temp.Evaluate(t);
            transform.position = Vector2.Lerp(startPos, originalPosition, ease);

            elapsed += Time.deltaTime;
        }
    }

    //getting the mouse pos for the game to recognise
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

}