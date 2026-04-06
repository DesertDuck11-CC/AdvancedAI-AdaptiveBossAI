using UnityEngine;

public class CounterSpell : Spell
{
    //NPC constructor
    public CounterSpell(Mage m) : base(m)
    {
        initValues();
    }

    //Player constructor
    public CounterSpell(Sprite image) : base(image)
    {
        initValues();
    }

    //init values override
    protected override void initValues()
    {
        aggroScale = -10;
        statusScale = 10;
        baseSpellValue = 1;
        spellValue = baseSpellValue; //Blocks 1 status effect
    }

    public override void cast(Mage enemy)
    {

    }
}
