using UnityEngine;

public class IgniteSpell : Spell
{
    //NPC constructor
    public IgniteSpell() : base()
    {
        initValues();
    }

    //Player constructor
    public IgniteSpell(Sprite image) : base(image)
    {
        initValues();
    }

    //init values override
    protected override void initValues()
    {
        aggroScale = 5;
        statusScale = 10;
        spellValue = 5;  //Applies 3-turn buff to self that makes all damaging spells apply burning (5 DOT for 4 turns)
    }
}
