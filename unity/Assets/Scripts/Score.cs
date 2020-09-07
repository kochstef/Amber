

//container for all the Scorepoints of the player 
public class Score
{
    //public string name;
    private int correctItems;
    private int forgottenItems;
    private int wrongItems;
    private float time;
    private int looksAtList;
    //public float timeNeeded;



    public Score(int correctItems, int forgottenItems, int wrongItems, float time, int looksAtList)
    {
        this.correctItems = correctItems;
        this.forgottenItems = forgottenItems;
        this.wrongItems = wrongItems;
        this.time = time;
        this.looksAtList = looksAtList;
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