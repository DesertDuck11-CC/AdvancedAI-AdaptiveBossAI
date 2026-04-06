using UnityEngine;

public class Status
{
    protected Mage owner;
    protected int duration;
    public bool positive;
    protected int potency;

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
}
