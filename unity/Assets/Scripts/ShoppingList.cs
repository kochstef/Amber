using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingList : MonoBehaviour
{
    
    // For showing the list------------------------------
    public GameObject listObject;
    private bool isCounting;
    public float timeToShowShoppingList = 3f;
    private float countdown;
 
    //For filling the List-------------------------------
    public TextMeshPro textmeshPro;
    private List<string> allItems;
    //this later should go over the server depending on the level of the patient
    private int amountOfItems = 6;
    private Dictionary<string, int> itemsToCollect;
    //the shoppingcart to check if all items have been collected
    private GameObject shoppingCart;
    
    void Start()
    {
        listObject.SetActive(false);
        isCounting = false;
        countdown = 3f; 
        
        //------------------------------------------
        allItems = new List<string>();
        allItems.Add("brown cube");
        allItems.Add("green cube");
        itemsToCollect = new Dictionary<string, int>();
        RandomItemsToCollect();
        shoppingCart = GameObject.Find("Shoppingcart");
        
        SetText();
        
       
    }

    
    
    //gets a random item from all items and puts it in a dictanary or increases the counter of the item
     private void RandomItemsToCollect()
    {
        List<string> items_to_collect = new List<string>();

        int randomIndex;
        string item_name;
        for (int i = 0; i < amountOfItems; i++)
        {
            
            randomIndex = Random.Range(0, allItems.Count);
            item_name = allItems[randomIndex];
            if(itemsToCollect.ContainsKey(item_name))
            {
                itemsToCollect[item_name] = itemsToCollect[item_name] + 1;
            }
            else
            {
                itemsToCollect.Add(item_name, 1); 
            }
        }
    }
     
     //Sets the items in the dictonary to the Shopping list 
     private void SetText()
     {
         textmeshPro.SetText(ToPrettyString());
         //textmeshPro.SetText(string.Join( "\n", itemsToCollect));
     }
    
     private string ToPrettyString()
     {
         string str = "";
        
         foreach (var pair in itemsToCollect)
         {
             str += string.Format(" {0} {1} \n", pair.Key, pair.Value);
         }
        
         return str;
     }
     
     private void ShowList()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.left);
        // Debug.DrawLine(transform.position, fwd, Color.green);
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, fwd, out hit, 10) && hit.collider.CompareTag("Head"))
        { 
            isCounting = true;
        }
        else 
        {
            isCounting = false;
            countdown = timeToShowShoppingList; 
            listObject.SetActive(false);
        }
 
        if(countdown <= 0f) 
        {
            listObject.SetActive(true);
        }
        if(isCounting) countdown -= Time.deltaTime;
    }

    //need something else cant teleport 
     private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
       // Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("exit"))
        {
            CheckIfItemsCollected();
        }
    }
    private void CheckIfItemsCollected()
    {
        Debug.Log(shoppingCart.transform.childCount);

        int forgotten_items = 0;
        int items_to_much = 0;
        foreach (var item in itemsToCollect)
        {
            int counter_of_items = 0;
            foreach(Transform child in shoppingCart.transform)
            {
                //this could be the problem
                Debug.Log("foreach loop :" + child.tag);
                if(child.CompareTag(item.Key))
                {
                    counter_of_items++;
                }
            }
            
           /* for(int i = 0; i < transform.childCount; i++)
            {
                Debug.Log("get child loop :" + transform.GetChild(i).tag);
                /// All your stuff with transform.GetChild(i) here...
            }*/
            
            Debug.Log(counter_of_items + "Counter of items" + " " + item.Key);
            if(counter_of_items <= item.Value)
            {
                forgotten_items += item.Value - counter_of_items;
            }
            else
            {
                items_to_much += counter_of_items - item.Value;
            }
        }

        items_to_much += GetNumberWrongItemsNotOnList();
        Debug.Log("you forgot " + forgotten_items + "and have " + items_to_much + "to much");
    }

    private int GetNumberWrongItemsNotOnList()
    {
        int wrong_items_count = 0;
        foreach(Transform child in shoppingCart.transform)
        {
            if (!itemsToCollect.ContainsKey(child.tag))
            {
                wrong_items_count++;
            }
        }
        return wrong_items_count;
    }
    void Update()
    {
        ShowList();
        
    }
    
}
