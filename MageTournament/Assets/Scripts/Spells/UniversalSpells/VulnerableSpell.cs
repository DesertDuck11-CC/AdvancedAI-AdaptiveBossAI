using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Vulnerable Spell", fileName = "Vulnerable Spell")]
public class VulnerableSpell : Spell
{

    //NPC constructor
    //public VulnerableSpell(Mage m) : base(m)
    //{
    //    initValues();
    //}

    ////Player constructor
    //public VulnerableSpell(Sprite image) : base(image)
    //{
    //    initValues();
    //}

    protected override void initValues()
    {
        aggroScale = 5;
        statusScale = 10;
        spellValue = 4; //Base spell value increases damage by 40%
    }
}
