using UnityEngine;

public class AttackSpell : Spell
{

    //NPC constructor
    public AttackSpell() : base()
    {
        initValues();
    }

    //Player constructor
    public AttackSpell(Sprite image) : base(image)
    {
        initValues();
    }

    //init values override
    protected override void initValues()
    {
        aggroScale = 10;
        statusScale = -10;
        spellValue = 15;
    }
}
