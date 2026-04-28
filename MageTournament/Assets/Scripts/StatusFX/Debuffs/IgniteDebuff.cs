using UnityEngine;

public class IgniteDebuff : Status
{
    public IgniteDebuff(Mage m)
    {
        owner = m;
        setStats();
    }

    protected override void setStats()
    {
        duration = 3;
        potency = 10;
        positive = false;
        aggro = -10;
        seenAggro = 25;
    }
}
