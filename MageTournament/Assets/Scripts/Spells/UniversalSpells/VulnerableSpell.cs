using UnityEngine;

public class VulnerableSpell : Spell
{

    //NPC constructor
    public VulnerableSpell() : base()
    {
        initValues();
    }

    //Player constructor
    public VulnerableSpell(Sprite image) : base(image)
    {
        initValues();
    }

    protected override void initValues()
    {
        aggroScale = 5;
        statusScale = 10;
        spellValue = 4; //Base spell value increases damage by 40%
    }
}
