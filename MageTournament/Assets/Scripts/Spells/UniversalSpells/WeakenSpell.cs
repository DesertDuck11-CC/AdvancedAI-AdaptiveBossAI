using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Weaken Spell", fileName = "Weaken Spell")]
public class WeakenSpell : Spell
{
    
    //NPC constructor
    //public WeakenSpell(Mage m) : base(m)
    //{
    //    initValues();
    //}

    ////Player constructor
    //public WeakenSpell(Sprite image) : base (image)
    //{
    //    initValues();
    //}

    protected override void initValues()
    {
        aggroScale = -5;
        statusScale = 10;
        spellValue = 3; //Base spell value reduces damage by 30%
    }

    public override void cast(Mage enemy)
    {
        WeakenDebuff wb = new WeakenDebuff(enemy);
        enemy.addStatus(wb);
    }
}
