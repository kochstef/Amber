using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCart : MonoBehaviour
{
    /*
     public Transform player;
     
    public float distanceTillTeleport = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject findClosestShelf()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("PositionShoppingCart");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = player.transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    
    // Update is called once per frame
    private void teleportShopingCart()
    {
        Debug.Log("TeleportShoppingCart");
        GameObject closestShelf = findClosestShelf();
        transform.position = closestShelf.transform.position;
        transform.rotation = closestShelf.transform.rotation;
        /* Vector3 pos = player.InverseTransformPoint(closestShelf.transform.position);
 
         if (pos.z < 0) 
             Debug.Log("Back ");
         else 
             Debug.Log("Front ");
 
         if (pos.x < 0)
             Debug.Log("Left ");
         else
             Debug.Log("Right ");
         */

        /*  Transform shoppingCartPosition = transform.Find("PositionShoppingCart");
          if(shoppingCartPosition != null){
         = shoppingCartPosition.position;
          }
    }
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) > distanceTillTeleport)
        {
            teleportShopingCart();
        }
    }*/
}
