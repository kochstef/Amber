using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingList : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject testCube;
    private bool isCounting;
    public float timeToShowShoppingList = 3f;
    private float countdown;
    //public TextMeshPro textmeshPro;
    void Start()
    {
        testCube.SetActive(false);
        isCounting = false;
        countdown = 3f; 
       // textmeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.left);
        Debug.DrawLine(transform.position, fwd, Color.green);
        RaycastHit hit;
        
        
        if (Physics.Raycast(transform.position, fwd, out hit, 10) && hit.collider.CompareTag("Head"))
        { 
            isCounting = true;
        }
        else 
        {
            isCounting = false;
            //This happens every frame the user isn't looking at an "option" so this could be optimized. But not a big problem.
            countdown = timeToShowShoppingList;
            //textmeshPro.renderer.enabled = false;
            testCube.SetActive(false);
        }
 
        if(countdown <= 0f) {
            //Select option
           textmeshPro.renderer.enabled = true;
           testCube.SetActive(true);
           Debug.Log(countdown);
           
        }
        if(isCounting) countdown -= Time.deltaTime;
      
    }
}
