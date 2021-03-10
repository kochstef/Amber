//container for all the Scorepoints of the player 

using System.Collections.Generic;

public class Score
{
    //public string name;
    private int correctItems;
    private int forgottenItems;
    private int wrongItems;
    private List<string> wrongItemsList;
    private  List<string>  correctItemsList;
    private float time;
    private int looksAtList;


    public  List<string> getWrongItemsList()
    {
        return wrongItemsList;
    }
    
    public  List<string> getCorrectItemsList()
    {
        return correctItemsList;
    }


    //public float timeNeeded;


    public Score(int correctItems, int forgottenItems, int wrongItems, float time, int looksAtList,
        List<string>  correctItemsList,  List<string>  wrongItemsList)
    {
        this.correctItems = correctItems;
        this.forgottenItems = forgottenItems;
        this.wrongItems = wrongItems;
        this.time = time;
        this.looksAtList = looksAtList;
        this.wrongItemsList = wrongItemsList;
        this.correctItemsList = correctItemsList;
        // this.timeNeeded = timeNeeded;
    }


    public int GetCorrectItems()
    {
        return correctItems;
    }

    public int GetForgottenItems()
    {
        return forgottenItems;
    }

    public int GetWrongItems()
    {
        return wrongItems;
    }

    public float GetTime()
    {
        return time;
    }

    public int GetLooksAtList()
    {
        return looksAtList;
    }
}