using UnityEngine;

public class Counterspell : Status
{
    public Counterspell(Mage m)
    {
        owner = m;
        setStats();
    }

    protected override void setStats()
    {
        duration = 1;
        potency = 1;
        positive = true;
        permanent = true;
    }
}
