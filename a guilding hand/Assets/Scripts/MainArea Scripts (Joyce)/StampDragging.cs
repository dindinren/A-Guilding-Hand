using UnityEngine;
using System.Collections;
using System.Collections.Generic; // Ensure this is included if you use List<T> or other collections

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

    public Animation anim;

    public Timer timerScript;

    public PauseMenu pauseMenu;
    public SpawnManager hasChanged;

    // Remove this line. You no longer need to manually find the AudioManager.
    // AudioManager_MainArea audioManager;

    private void Start()
    {
        tick.SetActive(false);
        hasChanged = FindAnyObjectByType<SpawnManager>();
    }

    private void Update()
    {
        // Finding objects by tag in Update() can be inefficient.
        // If these stamps are static, consider finding them once in Awake() or Start().
        GameObject correctStamp = GameObject.FindGameObjectWithTag("correct");
        GameObject incorrectStamp = GameObject.FindGameObjectWithTag("incorrect");

        if (correctStamp != null)
        {
            correctStamp.GetComponent<Collider2D>().enabled = !pauseMenu.isPause && timerScript.remainingTime > 0;
        }
        if (incorrectStamp != null)
        {
            incorrectStamp.GetComponent<Collider2D>().enabled = !pauseMenu.isPause && timerScript.remainingTime > 0;
        }
    }

    void Awake()
    {
        // Remove this line. You no longer need to manually assign the AudioManager.
        // audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_MainArea>();

        collider2d = GetComponent<Collider2D>();
        originalPosition = transform.position; // Store the initial position
    }

    // This method is called when the mouse button is pressed down over this object.
    void OnMouseDown()
    {
        // Access the AudioManager using its static 'Instance' property.
        if (AudioManager_MainArea.Instance != null)
        {
            // Call the method to play the SFX based on this GameObject's tag.
            // 'gameObject.tag' will be either "correct" or "incorrect".
            AudioManager_MainArea.Instance.PlaySFXForTaggedClick(gameObject.tag);
        }
        else
        {
            Debug.LogWarning("DragDrop2D: AudioManager_MainArea instance not found. Cannot play click SFX for tag: " + gameObject.tag, this);
        }

        offset = transform.position - MouseWorldPosition();
    }

    // The rest of your DragDrop2D script remains exactly as you provided it:

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        collider2d.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo;

        if (hitInfo = Physics2D.Raycast(rayOrigin, rayDirection))
        {
            if (hitInfo.transform.CompareTag(destinationTag))
            {
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);

                if (gameObject.CompareTag("correct"))
                {
                    if (adveninfovar.isItTheSame == true && cusname.areTheNameSame == true && spawnManager.finalResult() == true)
                    {
                        scoremanager.AddPoints();
                        if (AudioManager_MainArea.Instance != null) AudioManager_MainArea.Instance.PlaySFX(AudioManager_MainArea.Instance.Stamp);
                    }
                    else
                    {
                        scoremanager.MinusPoints();
                        if (AudioManager_MainArea.Instance != null) AudioManager_MainArea.Instance.PlaySFX(AudioManager_MainArea.Instance.Stamp);
                    }
                }
                else // Assuming it's "incorrect" tag
                {
                    if (adveninfovar.isItTheSame == false || cusname.areTheNameSame == false || spawnManager.finalResult() == false)
                    {
                        scoremanager.AddPoints();
                        if (AudioManager_MainArea.Instance != null) AudioManager_MainArea.Instance.PlaySFX(AudioManager_MainArea.Instance.Stamp);
                    }
                    else
                    {
                        scoremanager.MinusPoints();
                        if (AudioManager_MainArea.Instance != null) AudioManager_MainArea.Instance.PlaySFX(AudioManager_MainArea.Instance.Stamp);
                    }
                }

                StartCoroutine(DestroyAndRespawnAfterDelay(1f));
                Debug.Log("Object dropped in the drop area. It will be destroyed and respawned.");
                customerspawner.CustomerDelete();
            }
            else
            {
                returncheck = true;
                Debug.Log("Returned to original position.");
            }
        }
        else
        {
            returncheck = true;
            Debug.Log("Returned to original position.");
        }
        collider2d.enabled = true;
    }

    IEnumerator DestroyAndRespawnAfterDelay(float delay)
    {
        tick.SetActive(true);
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

        hasChanged.hasChanged = false;
        yield return new WaitForSeconds(delay);

        GameObject[] obj = GameObject.FindGameObjectsWithTag("QuestItemObject");
        foreach (GameObject ob in obj) { Destroy(ob); }
        GameObject[] obj2 = GameObject.FindGameObjectsWithTag("QuestFormObject");
        foreach (GameObject ob2 in obj2) { Destroy(ob2); }
        GameObject[] obj3 = GameObject.FindGameObjectsWithTag("AdventureFormObject");
        foreach (GameObject ob3 in obj3) { Destroy(ob3); }
        GameObject[] obj4 = GameObject.FindGameObjectsWithTag("QuestItemInitial");
        foreach (GameObject ob4 in obj4) { Destroy(ob4); }

        Debug.Log("Object destroyed!");
        tick.SetActive(false);
        cusname.nameText.enabled = false;
        cusname.nameText2.enabled = false;
        adveninfovar.PicIsDestroyed();
        Debug.Log("the pic will be destroyed");
    }

    private void FixedUpdate()
    {
        // Important: If ReturnToOriginalPosition() contains a while loop (which it does),
        // calling it directly in FixedUpdate() will freeze your game.
        // It needs to be an IEnumerator and started with StartCoroutine().
        if (returncheck == true)
        {
            ReturnToOriginalPosition();
        }
    }

    // This method, as written, will block your game if called outside a coroutine.
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
            // If this were an IEnumerator, you would have: yield return null;
        }
        returncheck = false;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}