using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingList : MonoBehaviour
{
    //outsource all except the List things

    public static ShoppingList instance;

    // For showing the list------------------------------
    public GameObject listObject;
    public float timeToShowShoppingList = 3f;
    private float countdown;
    private float countdownLookInterrupt;
    public float timeToInterruptLookAtList = 0.1f;
    public GameObject button;
    float timeRemaining = 5f;

    //For filling the List-------------------------------
    public TextMeshPro textmeshPro;

    public TextMeshPro textMeshProTime;

    //private List<string> allItems;
    //this later should go over the server depending on the level of the patient
    //private int amountOfItems = 6;
    //private Dictionary<string, int> itemsToCollect;
    //the shoppingcart to check if all items have been collected
    private GameObject shoppingCart;
    


    //for the loading animation 
    public GameObject animationObject;
    private float scale_y_original;
    private float scale_z_original;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new Exception("You have two ShoppingListsScripts in your scene. You can only have one");
        }

        listObject.SetActive(true);
        button.SetActive(true);
        countdown = 0.0f;
        Debug.Log(gameObject.name);
        GameManager.Instance.GameState = GameManager.GameStates.ExplanationState;
        GameManager.Instance.TeleportEnabled = false;
        animationObject.SetActive(false);

        scale_y_original = animationObject.transform.localScale.y;
        scale_z_original = animationObject.transform.localScale.z;
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
    public void SetText(Dictionary<string, int> itemsToCollect)
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
        Debug.DrawRay(transform.position, -transform.forward, Color.green);
        if (Physics.Raycast(transform.position, -transform.forward, out hit, 10) && hit.collider.CompareTag("Head"))
        {
            GameManager.Instance.TeleportEnabled = false;


            countdown += Time.deltaTime;
            countdownLookInterrupt = timeToInterruptLookAtList;
            if (!listObject.activeSelf)
            {
                float size = ((100 / timeToShowShoppingList) * countdown) / 100;
                animationObject.SetActive(true);
                animationObject.transform.localScale = new Vector3(animationObject.transform.localScale.x,
                    scale_y_original * size, scale_z_original * size);
            }

            if (countdown >= timeToShowShoppingList)
            {
                if (!listObject.activeSelf)
                {
                    GameManager.Instance.IncrementCounterLookedAtList();
                }

                animationObject.SetActive(false);
                listObject.SetActive(true);
                //deactivate loading list
            }
        }
        else if (countdown > 0.0f)
        {
            if (countdownLookInterrupt < 0.0f)
            {
                GameManager.Instance.TeleportEnabled = true;
                animationObject.SetActive(false);
                countdown = 0.0f;
                listObject.SetActive(false);
            }

            countdownLookInterrupt -= Time.deltaTime;
        }
    }

    public void startRoundHandler()
    {
        Debug.Log("button pushed");
        GameManager.Instance.SetTextList();
        // show timer on list
        // 
        // 
        GameManager.Instance.GameState = GameManager.GameStates.RememberItemsState;
        GameManager.Instance.TeleportEnabled = false;
        button.SetActive(false);

        //listObject.SetActive(false);
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
        if (GameManager.Instance.GameState == GameManager.GameStates.RoundHasStartedState)
        {
            ShowList();
        }
        else if (GameManager.Instance.GameState == GameManager.GameStates.RememberItemsState)
        {
            if (timeRemaining < 0f)
            {
                GameManager.Instance.TeleportEnabled = true;
                GameManager.Instance.GameState = GameManager.GameStates.RoundHasStartedState;
                listObject.SetActive(false);
                textMeshProTime.SetText("");
            }
            else
            {
                // Debug.Log("Timer");
                textMeshProTime.SetText(timeRemaining.ToString());
                timeRemaining -= Time.deltaTime;
            }
        }
    }

    /* IEnumerator WaitCoroutine()
     {
         //Print the time of when the function is first called.
         Debug.Log("Started Coroutine at timestamp : " + Time.time);
 
         //yield on a new YieldInstruction that waits for 5 seconds.
         yield return new WaitForSeconds(5);
 
         //After we have waited 5 seconds print the time again.
         Debug.Log("Finished Coroutine at timestamp : " + Time.time);
     }
     */
}