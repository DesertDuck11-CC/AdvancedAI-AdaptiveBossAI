using UnityEngine;

public class BlizzardSpell : Spell
{
    //NPC constructor
    public BlizzardSpell(Mage m) : base(m)
    {
        initValues();
    }

    //Player constructor
    public BlizzardSpell(Sprite image) : base(image)
    {
        initValues();
    }

    //init values override
    protected override void initValues()
    {
        aggroScale = 7;
        statusScale = -5;
        spellValue = 10;  //Deals 10 damage and applies brittle which deals a burst of damage when the affected mage's shield is broken
    }
}
