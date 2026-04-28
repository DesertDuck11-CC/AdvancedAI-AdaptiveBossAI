using UnityEngine;

public class WeakenDebuff : Status
{
    
    public WeakenDebuff(Mage m)
    {
        owner = m;
        setStats();
    }

    protected override void setStats()
    {
        duration = 3;
        potency = 30;
        positive = false;
        aggro = -10;
        seenAggro = -10;
    }
}
