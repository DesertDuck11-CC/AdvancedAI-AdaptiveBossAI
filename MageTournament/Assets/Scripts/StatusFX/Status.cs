using UnityEngine;

public class Status
{
    protected Mage owner;
    public int duration;
    public bool positive;
    public int potency;
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
