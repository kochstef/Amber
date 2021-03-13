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

    public static GameManager Instance = null;

    public GameObject shoppingCart;
    public TextMeshPro exitText;
    public EndUI endUI;
    private int counterLokedAtList = 0;
    public bool trackTime = false;
    private float time = 0f;
    public bool test = false;
    private float countDownList = 0.0f;
    private List<string> listLooksAtList;
    
   public enum GameStates
    {
        ExplanationState,
        RememberItemsState,
        RoundHasStartedState,
        RoundHasEnded
    }

    public GameStates _gameState = GameStates.ExplanationState;

    public GameStates GameState
    {
        get => _gameState;
        set => _gameState = value;
    }


    public bool TeleportEnabled { get; set; }

    protected GameManager()
    {
    }


    // public event OnStateChangeHandler OnStateChange;
    // public  GameState gameState { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new Exception("You have two game managers in your scene. You can only have one game manager");
        }

        DontDestroyOnLoad(gameObject);
        TeleportEnabled = false;
        ParametersForGame.InitParametersForGame(6);
        listLooksAtList = new List<string>();
    }

    private void Start()
    {
        //startGame();
    }

    public void SetTextList()
    {
        ShoppingList.instance.SetText(ParametersForGame.Instance().GetItemsToCollect());
    }

    public void StartCountdownLookAtList()
    {
        countDownList = time;
    }

    public void StopCountdownLookAtList()
    {
        if (countDownList > 0.01f)
        {
            countDownList = time - countDownList;
            string timeLook = string.Format("{0}:{1:00}", (int) time / 60, (int) time % 60);
            string timeFor = string.Format("{0}:{1:00}", (int) countDownList / 60, (int) countDownList % 60);
            countDownList = 0.0f;
            listLooksAtList.Add(timeLook + " for " + timeFor);
        }
    }
    

    public void endRound()
    {
       
        ShoppingCart shoppingCartScript = shoppingCart.GetComponent<ShoppingCart>();
        List<string> itemsInShoppingCart = shoppingCartScript.GetTagsChildren();


        Score score = CalculateScore.CalcScore(itemsInShoppingCart, ParametersForGame.Instance().GetItemsToCollect(),
            time, counterLokedAtList);
        foreach (var item in itemsInShoppingCart)
        {
            Debug.Log(item);
        }
       
        Debug.Log("Round has ended");
        exitText.enabled = false;
        
        
        //exitText.SetText("Forgotten: " + score.GetForgottenItems() + "\n Too much: " + score.GetWrongItems()
         //                + "\n Time: " + score.GetTime() + "\n Looks at list: " + score.GetLooksAtList());
        endUI.OpenDoor();
        endUI.ShowList(score.getCorrectItemsList(), score.getWrongItemsList(), score.GetTime(), listLooksAtList);
        
        //  Debug.Log("you forgot " + score.GetForgottenItems() + "and have " + score.GetWrongItems() + "to much");
        //calculate points
        GameState = GameStates.RoundHasEnded;
    }

    public void IncrementCounterLookedAtList()
    {
        counterLokedAtList++;
    }

    void Update()
    {
        if (GameState == GameStates.RoundHasStartedState)
        {
            time += Time.deltaTime;
        }

        if (test)
        {
            endRound();
        }
    }
}