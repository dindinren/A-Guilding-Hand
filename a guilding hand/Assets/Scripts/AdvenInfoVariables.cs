using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvenInfoVariables :MonoBehaviour
{
    public CustomerSpawner customerPic;

    GameObject rawCustomerPic;

    public bool canRandomize = false;


    //assign a number depending on the amount of customers there
    public void AssignVariables()
    {
        int[] advenVar = new int[customerPic.CustomersToSpawn.Count];

        for (int i = 0; i < advenVar.Length; i++)
        {
            advenVar[i] += i;
        }
        //random spawn
        int index = Random.Range(0, advenVar.Length);
    }

    //i want that once a customer spawn the card would also spawn that customers face
    public void Start()
    {

        Debug.Log("HELLO");

        //if no randomise, the pic will spawn as the same as the customer on the left
        if (canRandomize == false)
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

        }
        else
        {
            int selectedID = Random.Range(0, customerPic.CustomersToSpawn.Count);
            while(selectedID == customerPic.index)
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

    public void PicIsDestroyed()
    {
        //StartCoroutine(DestroyPic(1f));
        Destroy(rawCustomerPic);
    }

    IEnumerator DestroyPic(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(rawCustomerPic);

    }
}
