using UnityEngine;

public class Charge : Status
{
    public Charge(Mage m)
    {
        owner = m;
        setStats();
    }

    protected override void setStats()
    {
        duration = 2;
        potency = 2;
        positive = true;
    }
}
