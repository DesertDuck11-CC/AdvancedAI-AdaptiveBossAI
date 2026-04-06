using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Fire Mage/Twin Fireball Spell", fileName = "Twin Fireball Spell")]
public class TwinFireballSpell : Spell
{
    //NPC constructor
    //public TwinFireballSpell(Mage m) : base(m)
    //{
    //    initValues();
    //}

    ////Player constructor
    //public TwinFireballSpell(Sprite image) : base(image)
    //{
    //    initValues();
    //}

    //init values override
    protected override void initValues()
    {
        aggroScale = 10;
        statusScale = -10;
        spellValue = 10;  //This spell does 10 damage twice
    }
}
