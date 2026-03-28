using UnityEngine;

public class DefenseSpell : Spell
{
    
    //NPC constructor
    public DefenseSpell() : base()
    {
        initValues();
    }

    //Player constructor
    public DefenseSpell(Sprite image) : base(image)
    {
        initValues();
    }

    //init values override
    protected override void initValues()
    {
        aggroScale = -5;
        statusScale = 0;
        spellValue = 10;
    }


}
