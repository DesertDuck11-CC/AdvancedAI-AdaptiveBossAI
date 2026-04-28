using UnityEngine;

public class Status
{
    protected Mage owner;
    public int duration;
    public bool positive;
    public int potency;
    public int aggro;   //This aggro value is read as how the player should respond to having the status on them.  Positive aggro = just attack while negative aggro = defend
    public int seenAggro;  //This value is read as how the player should respond to their opponent having this status.  Postivie aggro = just attack while negative aggro = defend
    protected bool permanent = false;

    public Status()
    {
        owner = null;
        setStats();
    }

    protected virtual void setStats()
    {
        duration = 0;
        potency = 0;
    }


    public bool nextTurn()
    {
        duration--;
        if(!permanent && duration <= 0)
        {
            return true;
        }
        return false;
    }
}
