using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Frost Mage/Ice Wall Spell", fileName = "Ice Wall Spell")]
public class IceWallSpell : Spell
{
    //NPC constructor
    //public IceWallSpell(Mage m) : base(m)
    //{
    //    initValues();
    //}

    ////Player constructor
    //public IceWallSpell(Sprite image) : base(image)
    //{
    //    initValues();
    //}

    //init values override
    protected override void initValues()
    {
        aggroScale = -10;
        statusScale = -10;
        spellValue = 20;
    }

    public override void cast(Mage enemy)
    {
        owner.defend(spellValue);
    }
}
