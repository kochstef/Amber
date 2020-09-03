using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shoppingCart;
    
    void Awake()
    {
        ParametersForGame.InitParametersForGame(6);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endRound()
    {
        List<string> itemsInShoppingCart = shoppingCart.GetComponent<ShoppingCart>().GetTagsChildren();

        Score score = CalculateScore.CalcScore(itemsInShoppingCart, ParametersForGame.Instance().GetItemsToCollect());
        Debug.Log("Round has ended");
        
        Debug.Log("you forgot " + score.GetForgottenItems() + "and have " + score.GetWrongItems() + "to much");
        //calculate points
    }
}
