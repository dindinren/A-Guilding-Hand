using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AdvenInfoVariables :MonoBehaviour
{
    public CustomerSpawner customerPic;

    public GameObject rawCustomerPic;

    public bool canRandomizeAdven = false;
    public bool isItTheSame = false; 


    //i want that once a customer spawn the card would also spawn that customers face
    public void Start()
    {
        int selectedID = customerPic.index;

        //random choose to spawn the same pic or diff pic
        ProfilePicRandomise();

        Debug.Log("HELLO");

        //if no randomise, the pic will spawn as the same as the customer on the left
        if (canRandomizeAdven == false)
        {
            Debug.Log("the adven card info will spawn with the customer");
            if (customerPic != null)
            {
                rawCustomerPic = Instantiate(customerPic.lastSpawnedObject, GameObject.FindGameObjectWithTag("CustomerSmallPicSP").transform);
                rawCustomerPic.transform.localPosition = Vector3.zero;
                rawCustomerPic.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("Foreground");
                rawCustomerPic.GetComponent<SpriteRenderer>().sortingOrder = 3;
                Debug.Log("AHHHHHHHHH");
            }

            if (customerPic.index == selectedID)
            {
                isItTheSame = true;
                Debug.Log("PLEASE DFOES THIS WORKS???");
            }


        }
        else
        {
            selectedID = Random.Range(0, customerPic.CustomersToSpawn.Count);
            while (selectedID == customerPic.index)
            {
                selectedID = Random.Range(0, customerPic.CustomersToSpawn.Count);
            }
            rawCustomerPic = Instantiate(customerPic.CustomersToSpawn[selectedID], GameObject.FindGameObjectWithTag("CustomerSmallPicSP").transform);
            rawCustomerPic.transform.localPosition = Vector3.zero;
            rawCustomerPic.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("Foreground");
            rawCustomerPic.GetComponent<SpriteRenderer>().sortingOrder = 3;
            Debug.Log("this works");
        }
    }


    //allow for randomly change the profile pic each time a customer spawn
    public void ProfilePicRandomise()
    {
        int randomvalue = Random.Range(0, 2);

        if(randomvalue == 0)
        {
            canRandomizeAdven = false;
        }
        else
        {
            canRandomizeAdven = true;
        }
    }

    public void PicIsDestroyed()
    {
        Destroy(rawCustomerPic);
    }
}
