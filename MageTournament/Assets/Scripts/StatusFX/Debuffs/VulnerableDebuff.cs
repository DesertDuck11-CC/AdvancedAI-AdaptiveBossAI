using UnityEngine;

public class VulnerableDebuff : Status
{
    public VulnerableDebuff(Mage m)
    {
        owner = m;
        setStats();
    }

    protected override void setStats()
    {
        duration = 3;
        potency = 40;
        positive = false;
        aggro = -15;
        seenAggro = 15;
    }
}
