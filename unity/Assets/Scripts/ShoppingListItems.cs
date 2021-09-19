using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ShoppingListItems : MonoBehaviour
{

    public GameObject textField;
    
    public float offset;
    public Vector3 positionFirstTextfield;


   

    // Start is called before the first frame update
    public void setItemsAndAmount(Dictionary<string, int> itemsToCollect)
    {
        Vector3 positionSpawn = positionFirstTextfield;
        foreach (var item in itemsToCollect)
        {
           GameObject textfield = Instantiate(textField, transform);
           //textfield.transform.rotation = Quaternion.Euler(90, 0, 0);
           textfield.transform.localPosition = new Vector3(positionFirstTextfield.x,positionFirstTextfield.y - offset, positionFirstTextfield.z);
           Canvas canvas = textfield.GetComponentInChildren<Canvas>();
           Transform transformName = canvas.transform.Find("Item");
          // Transform transformAmount = canvas.transform.Find("Amount");
       //    TextMeshProUGUI name = canvas.GetComponentInChildren<TMPro.TextMeshProUGUI>();
           TextMeshProUGUI[] textfileds = canvas.GetComponentsInChildren<TMPro.TextMeshProUGUI>();
         //  TextMeshProUGUI amount = canvas.GetComponentInChildren<TMPro.TextMeshProUGUI>();

           positionFirstTextfield.y -= offset;
           textfileds[0].text = item.Key;//item.Key;
           textfileds[1].text = item.Value.ToString();
          // TextMeshPro name1 = canvas.GetComponentInChildren<TMPro.TextMeshPro>();
           if (name == null)
           {
               
           }
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
