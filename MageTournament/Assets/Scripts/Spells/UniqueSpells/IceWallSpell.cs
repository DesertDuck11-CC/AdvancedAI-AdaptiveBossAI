using UnityEngine;

public class IceWallSpell : Spell
{
    //NPC constructor
    public IceWallSpell() : base()
    {
        initValues();
    }

    //Player constructor
    public IceWallSpell(Sprite image) : base(image)
    {
        initValues();
    }

    //init values override
    protected override void initValues()
    {
        aggroScale = -10;
        statusScale = -10;
        spellValue = 20;
    }
}
