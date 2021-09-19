using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalculateScore

{
    public static Score CalcScore(List<string> itemsCollected, Dictionary<string, int> itemsToCollect, float time,
        int counterLokedAtList)
    {
        //  Debug.Log(shopping_cart.transform.childCount);
        List<string> correctItemsList = new List<string>();
        List<string> wrongItemsList = new List<string>();
        int forgottenItems = 0;
        int wrongItems = 0;

        List<string> itemsToCollectList = new List<string>();
        foreach (var it in itemsToCollect)
        {
            itemsToCollectList.Add(it.Key);
        }
        
        
        foreach (var it in itemsToCollectList)
        {
            if (itemsCollected.Contains(it))
            {
                correctItemsList.Add(it);
                itemsCollected.Remove(it);
            }
            else
            {
                wrongItemsList.Add(it);
            }
        }
        
        /*
        foreach (var itemToColl in itemsToCollect)
        {
            int counterOfItems = 0;
            foreach (string itemIsColl in itemsCollected)
            {
                //this could be the problem
                //Debug.Log("foreach loop :" + child.tag);
                if (itemIsColl.Equals(itemToColl.Key))
                {
                    counterOfItems++;
                }
            }

            Debug.Log(counterOfItems + "Counter of items" + " " + itemToColl.Key);
            if (counterOfItems <= itemToColl.Value)
            {
                forgottenItems += itemToColl.Value - counterOfItems;
            }
            else
            {
                wrongItems += counterOfItems - itemToColl.Value;
                wrongItemsList.Add(itemToColl.Key);
            }
        }

       
        wrongItems +=
            GetNumberWrongItemsNotOnList(itemsCollected, itemsToCollect, correctItemsList, wrongItemsList);
        */

        return new Score(0, forgottenItems, wrongItems, time, counterLokedAtList, correctItemsList, wrongItemsList);
    }

    private static int GetNumberWrongItemsNotOnList(List<string> itemsCollected, Dictionary<string, int> itemsToCollect,
        List<string> correctItemsList, List<string> wrongItemsList)
    {
        int wrong_items_count = 0;
        foreach (string item in itemsCollected)
        {
            if (!itemsToCollect.ContainsKey(item))
            {
                wrong_items_count++;
               // wrongItemsList.Add(item);
            }
            else
            {
                correctItemsList.Add(item);
            }
        }

        return wrong_items_count;
    }
}