using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingCart : MonoBehaviour
{
    
    public Transform player;
     
    public float distanceTillTeleport = 1f;
    

    private GameObject findClosestShelf()
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
    
    private void teleportShopingCart()
    {
        //Debug.Log("TeleportShoppingCart");
        GameObject closestShelf = findClosestShelf();
        transform.position = closestShelf.transform.position;
        transform.rotation = closestShelf.transform.rotation;
    }
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) > distanceTillTeleport)
        {
            teleportShopingCart();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("green cube")
           || other.transform.CompareTag("brown cube")
        )
        {
            other.transform.parent = transform;
     //       other.transform.tag = "green cube";
        }
    }
}
