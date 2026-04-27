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
        potency = 10;
        positive = false;
    }
}
