using UnityEngine;

public class WeakenSpell : Spell
{
    
    //NPC constructor
    public WeakenSpell() : base()
    {
        initValues();
    }

    //Player constructor
    public WeakenSpell(Sprite image) : base (image)
    {
        initValues();
    }

    protected override void initValues()
    {
        aggroScale = -5;
        statusScale = 10;
        spellValue = 3; //Base spell value reduces damage by 30%
    }
}
