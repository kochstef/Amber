using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;


public class ParametersForGame
{
    private static ParametersForGame _instance = null;
    public static ParametersForGame Instance()
    {
        if(_instance == null)
        {
            throw new Exception("You need to initialize ParametersForGame, before you call Instace, " +
                                "by calling initParametersForGame");
        }
        return _instance;
    }
    
    
    //a list of tags of the Items you can collect
    //if you add a item you need to add the tag here
    public List<string> allItems = new List<string>()
    {
        "Onion",
        "Carrot",
        "Orange",
        "Apple",
        "CocaCola",
        "Milk"
    };
    private Dictionary<string, int> itemsToCollect = null;

    
    //initializes the parameter for the games depending on the settings
    public static void InitParametersForGame(int settings)
    {
       _instance = new ParametersForGame(); 
       _instance.RandomItemsToCollect(settings);
    }
    
    //Returns the Items to collect;
    public Dictionary<string, int> GetItemsToCollect()
    {
        return itemsToCollect;
    }

    //creates a random dictionary with items to collect and the amount of the items from the List all items with
    //the tags of the game objects in the list  
    private void RandomItemsToCollect(int amountOfItems)
    {
        
        itemsToCollect = new Dictionary<string, int>();
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
}
