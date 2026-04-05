using UnityEngine;

public class CounterSpell : Spell
{
    //NPC constructor
    public CounterSpell() : base()
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
        spellValue = 1; //Blocks 1 status effect
    }
}
