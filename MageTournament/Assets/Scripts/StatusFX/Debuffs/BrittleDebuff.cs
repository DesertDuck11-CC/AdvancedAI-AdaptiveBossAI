using UnityEngine;

public class BrittleDebuff : Status
{
    public BrittleDebuff(Mage m)
    {
        owner = m;
        setStats();
    }

    protected override void setStats()
    {
        duration = 4;
        potency = 7;
        positive = false;
        aggro = 8;
        seenAggro = 15;
    }
}
