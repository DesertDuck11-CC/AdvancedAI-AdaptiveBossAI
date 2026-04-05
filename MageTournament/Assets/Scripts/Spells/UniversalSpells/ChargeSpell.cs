using UnityEngine;

public class ChargeSpell : Spell
{
    //NPC constructor
    public ChargeSpell() : base()
    {
        initValues();
    }

    //Player constructor
    public ChargeSpell(Sprite image) : base(image)
    {
        initValues();
    }

    protected override void initValues()
    {
        aggroScale = 0;
        statusScale = 0;
        spellValue = 2; //Doubles spell value of next spell
    }
}
