using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingList : MonoBehaviour
{
    //outsource all except the List things
    
    // For showing the list------------------------------
    public GameObject listObject;
    private bool isCounting;
    public float timeToShowShoppingList = 3f;
    private float countdown;
 
    //For filling the List-------------------------------
    public TextMeshPro textmeshPro;
    //private List<string> allItems;
    //this later should go over the server depending on the level of the patient
    //private int amountOfItems = 6;
    //private Dictionary<string, int> itemsToCollect;
    //the shoppingcart to check if all items have been collected
    private GameObject shoppingCart;
    
    void Start()
    {
        listObject.SetActive(false);
        isCounting = false;
        countdown = 3f; 
        Debug.Log(gameObject.name);
        SetText(ParametersForGame.Instance().GetItemsToCollect());
        //------------------------------------------
       /* allItems = new List<string>();
        allItems.Add("brown cube");
        allItems.Add("green cube");
        */
       // itemsToCollect = new Dictionary<string, int>();
        //RandomItemsToCollect();
        //shoppingCart = GameObject.Find("Shoppingcart");
    }

    
    //Sets the items in the dictonary to the Shopping list 
     private void SetText(Dictionary<string, int> itemsToCollect)
     {
         string listText = ToPrettyString(itemsToCollect);
         textmeshPro.SetText(listText);
         //textmeshPro.SetText(string.Join( "\n", itemsToCollect));
     }
    
     private string ToPrettyString(Dictionary<string, int> itemsToCollect)
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
    /*
     private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
       // Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("exit"))
        {
            Score score = CalculateScore.CheckIfItemsCollected(new List<string>(), itemsToCollect);
        }
    }
  */
    void Update()
    {
        ShowList();
        
    }
    
}
