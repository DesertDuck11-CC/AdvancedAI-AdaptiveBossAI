using UnityEngine;

public class BurningDebuff : Status
{
    public BurningDebuff(Mage m)
    {
        owner = m;
        setStats();
    }

    protected override void setStats()
    {
        duration = 2;
        potency = 3;
        positive = false;
        aggro = -10;
        seenAggro = 10;
    }
}
