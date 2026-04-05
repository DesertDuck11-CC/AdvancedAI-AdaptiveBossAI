using UnityEngine;

public class TwinFireballSpell : Spell
{
    //NPC constructor
    public TwinFireballSpell() : base()
    {
        initValues();
    }

    //Player constructor
    public TwinFireballSpell(Sprite image) : base(image)
    {
        initValues();
    }

    //init values override
    protected override void initValues()
    {
        aggroScale = 10;
        statusScale = -10;
        spellValue = 10;  //This spell does 10 damage twice
    }
}
