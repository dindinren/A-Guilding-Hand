using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Make sure this is present for Button and UI elements

public class Guidebook_Main : MonoBehaviour
{
    [Header("Guidebook Pages & Containers")]
    public GameObject guidebook; // The main GameObject that contains all guidebook elements
    public List<GameObject> guidebookList; // List of individual page GameObjects

    [Header("Navigation Arrows")]
    public GameObject arrowForward;
    public GameObject arrowBackward;

    [Header("Control Buttons")]
    public Button guidebookButton; // The button that triggers the guidebook to appear
    public GameObject closeGuidebookButton; // The button that closes the guidebook (assign in Inspector!)

    private int currentindex = 0; // Tracks the current active page index
    private Animator anim; // Reference to the Animator component on this GameObject

    AudioManager_MainArea audioManager; // Reference to the Audio Manager

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager_MainArea>();
        if (audioManager == null)
        {
            Debug.LogError("Guidebook_Main Awake: AudioManager_MainArea not found! Make sure it's in the scene and tagged 'AudioManager'.", this);
        }
    }

    void Start()
    {
        // Get the Animator component from this GameObject
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Guidebook_Main Start: Animator component not found on this GameObject.", this);
        }

        // Initially hide the main guidebook container
        guidebook.SetActive(false);

        // Ensure the close button is initially inactive/hidden
        if (closeGuidebookButton != null)
        {
            closeGuidebookButton.SetActive(false);
        }
        else
        {
            Debug.LogError("Guidebook_Main Start: 'closeGuidebookButton' is not assigned in the Inspector! Please assign it.", this);
        }

        // Set initial state of navigation arrows (assuming they are children of 'guidebook' and will be set active/inactive by GuidebookPages)
        if (arrowForward != null) arrowForward.SetActive(false);
        if (arrowBackward != null) arrowBackward.SetActive(false);


        // Set the initial state of the main guidebook open button
        if (guidebookButton != null)
        {
            guidebookButton.interactable = true; // Ensure it's clickable at the start
            guidebookButton.onClick.AddListener(GuidebookAppear); // Assign the click listener
        }
        else
        {
            Debug.LogError("Guidebook_Main Start: 'guidebookButton' is not assigned in the Inspector! Please assign it.", this);
        }
    }

    // Update is called once per frame (currently empty)
    void Update()
    {
        // No Update logic needed here for now
    }

    // Manages which guidebook page is active and updates arrow visibility
    public void GuidebookPages()
    {
        // Deactivate all pages first to ensure only one is active
        foreach (GameObject page in guidebookList)
        {
            if (page != null)
            {
                page.SetActive(false);
            }
        }

        // Activate the current page if it's within bounds and not null
        if (currentindex >= 0 && currentindex < guidebookList.Count && guidebookList[currentindex] != null)
        {
            guidebookList[currentindex].SetActive(true);
        }
        else
        {
            Debug.LogWarning($"Guidebook_Main: currentindex ({currentindex}) is out of bounds or a page in 'guidebookList' is null. Check list size and assigned pages.", this);
        }

        // Manage arrow visibility based on current index
        if (arrowForward != null)
        {
            arrowForward.SetActive(currentindex < guidebookList.Count - 1);
        }
        else
        {
            Debug.LogWarning("Guidebook_Main: 'arrowForward' is not assigned in the Inspector.", this);
        }

        if (arrowBackward != null)
        {
            arrowBackward.SetActive(currentindex > 0);
        }
        else
        {
            Debug.LogWarning("Guidebook_Main: 'arrowBackward' is not assigned in the Inspector.", this);
        }
    }

    // Called when the forward arrow is clicked
    public void Forward()
    {
        Debug.Log("Guidebook: Forward button clicked.");
        // Ensure we don't go out of bounds (past the last page)
        if (currentindex < guidebookList.Count - 1)
        {
            currentindex++;
            GuidebookPages(); // Update page display and arrows

            if (audioManager != null)
            {
                audioManager.PlayRandomGuidebookFlipSFX();
            }
        }
        else
        {
            Debug.Log("Guidebook: Already on the last page. Cannot go further forward.");
        }
    }

    // Called when the backward arrow is clicked
    public void Backward()
    {
        Debug.Log("Guidebook: Backward button clicked.");
        // Ensure we don't go out of bounds (before the first page)
        if (currentindex > 0)
        {
            currentindex--;
            GuidebookPages(); // Update page display and arrows

            if (audioManager != null)
            {
                audioManager.PlayRandomGuidebookFlipSFX();
            }
        }
        else
        {
            Debug.Log("Guidebook: Already on the first page. Cannot go further backward.");
        }
    }

    // Called when the main guidebook button is clicked to make it appear
    public void GuidebookAppear()
    {
        // Play click sound when the button is pressed
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.ClickSFX);
        }

        // Disable the main guidebook open button immediately to prevent re-clicks while open
        if (guidebookButton != null)
        {
            guidebookButton.interactable = true;
            Debug.Log("Guidebook Appear: Guidebook Button Interactable set to TRUE.");
        }
        else
        {
            Debug.LogWarning("Guidebook_Main GuidebookAppear: 'guidebookButton' is null. Cannot set interactable.", this);
        }

        // Activate the main guidebook container
        guidebook.SetActive(true);
        // Play the "OnEnter" animation
        anim.Play("Guidebook_Tutorial-OnEnter");

        // Activate the close button when the guidebook appears
        if (closeGuidebookButton != null)
        {
            closeGuidebookButton.SetActive(true);
        }
        else
        {
            Debug.LogError("Guidebook_Main GuidebookAppear: 'closeGuidebookButton' is not assigned. Cannot activate it.", this);
        }

        // Reset to the first page and update display when opening the guidebook
        currentindex = 0;
        GuidebookPages();
    }

    // Public method to start the coroutine for closing the guidebook
    public void GuidebookGoByeBye()
    {
        // Play click sound when the close button is pressed
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.ClickSFX);
        }

        StartCoroutine(GuidebookGoByeByeTiming(1f)); // Assumes a 1-second animation/delay for exit
    }

    // Coroutine to handle the guidebook closing animation and state changes
    IEnumerator GuidebookGoByeByeTiming(float delay)
    {
        // Play the "OnExit" animation
        anim.Play("Guidebook_Tutorial-OnExit");

        // Deactivate the close button as the guidebook is closing
        if (closeGuidebookButton != null)
        {
            closeGuidebookButton.SetActive(false);
        }

        // Wait for the specified delay (e.g., animation duration)
        yield return new WaitForSeconds(delay);

        // Deactivate the main guidebook container
        guidebook.SetActive(false);

        // Re-enable the main guidebook open button after the guidebook has fully disappeared
        if (guidebookButton != null)
        {
            guidebookButton.interactable = true;
            Debug.Log("Guidebook Go Bye Bye: Guidebook Button Interactable set to TRUE.");
        }
        else
        {
            Debug.LogWarning("Guidebook_Main GuidebookGoByeByeTiming: 'guidebookButton' is null. Cannot set interactable.", this);
        }
    }
}