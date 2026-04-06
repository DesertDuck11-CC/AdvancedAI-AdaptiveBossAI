using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Defense Spell", fileName = "Defense Spell")]
public class DefenseSpell : Spell
{
    
    //NPC constructor
    //public DefenseSpell(Mage m) : base(m)
    //{
    //    initValues();
    //}

    ////Player constructor
    //public DefenseSpell(Sprite image) : base(image)
    //{
    //    initValues();
    //}

    //init values override
    protected override void initValues()
    {
        aggroScale = -10;
        statusScale = -10;
        baseSpellValue = 10;
        spellValue = baseSpellValue;
    }

    public override void cast(Mage enemy)
    {
        owner.defend(spellValue);
    }
}
