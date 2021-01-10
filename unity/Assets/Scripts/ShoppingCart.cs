using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCart : MonoBehaviour
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
        if(ParametersForGame.Instance().allItems.Contains(other.transform.tag))
        {
            other.transform.parent = transform;
        }
    }

    public List<string> GetTagsChildren()
    {
        List<string> tagsChildren = new List<string>();

        foreach (Transform child in transform)
        {
            tagsChildren.Add(child.tag);
        }
        return tagsChildren;
    }
}
