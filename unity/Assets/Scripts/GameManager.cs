using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


// Game States
// for later when changing scences
//public enum GameState { INTRO, MAIN_MENU }

//public delegate void OnStateChangeHandler();


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager instance = null;

    public GameObject shoppingCart;
    public TextMeshPro exitText;

    protected GameManager()
    {
    }



    // public event OnStateChangeHandler OnStateChange;
    // public  GameState gameState { get; private set; }

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new Exception("You have two game managers in your scene. You can only have one game manager");
        }

        DontDestroyOnLoad(gameObject);

        ParametersForGame.InitParametersForGame(6);
    }

    private void Start()
    {
        //startGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
        ShoppingList.instance.SetText(ParametersForGame.Instance().GetItemsToCollect());
    }

public void endRound()
    {
        List<string> itemsInShoppingCart = shoppingCart.GetComponent<ShoppingCart>().GetTagsChildren();

        Score score = CalculateScore.CalcScore(itemsInShoppingCart, ParametersForGame.Instance().GetItemsToCollect());
        Debug.Log("Round has ended");
        
        exitText.SetText("You forgot " + score.GetForgottenItems() + "and have " + score.GetWrongItems() + "to much.");
        Debug.Log("you forgot " + score.GetForgottenItems() + "and have " + score.GetWrongItems() + "to much");
        //calculate points
    }
    
    
    
}
