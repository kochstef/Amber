

//container for all the Scorepoints of the player 
public class Score
{
    //public string name;
    private int correctItems;
    private int forgottenItems;
    private int wrongItems;
    //public float timeNeeded;
    
        
        
    public Score(int correctItems, int forgottenItems, int wrongItems)
    {
        this.correctItems = correctItems;
        this.forgottenItems = forgottenItems;
        this.wrongItems = wrongItems;
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
    
}