using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalculateScore
{
    // Start is called before the first frame update
    public static Score CalcScore(List<string> itemsCollected , Dictionary<string, int> itemsToCollect)
    {
      //  Debug.Log(shopping_cart.transform.childCount);

        int forgottenItems = 0;
        int wrongItems = 0;
        foreach (var itemToColl in itemsToCollect)
        {
            int counterOfItems = 0;
            foreach(string itemIsColl in itemsCollected)
            {
                //this could be the problem
                //Debug.Log("foreach loop :" + child.tag);
                if(itemIsColl.Equals(itemToColl.Key))
                {
                    counterOfItems++;
                }
            }

            Debug.Log(counterOfItems + "Counter of items" + " " + itemToColl.Key);
            if(counterOfItems <= itemToColl.Value)
            {
                forgottenItems += itemToColl.Value - counterOfItems;
            }
            else
            {
                wrongItems += counterOfItems - itemToColl.Value;
            }
        }

        wrongItems += GetNumberWrongItemsNotOnList(itemsCollected, itemsToCollect);
        
        
        return new Score(0,forgottenItems,wrongItems);
    }

    private static int GetNumberWrongItemsNotOnList(List<string> itemsCollected, Dictionary<string, int> itemsToCollect)
    {
        int wrong_items_count = 0;
        foreach(string item in itemsCollected)
        {
            if (!itemsToCollect.ContainsKey(item))
            {
                wrong_items_count++;
            }
        }
        return wrong_items_count;
    }
}
