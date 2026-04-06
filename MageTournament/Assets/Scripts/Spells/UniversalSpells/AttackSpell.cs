using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Attack Spell", fileName = "Attack Spell")]
public class AttackSpell : Spell
{

    //NPC constructor
    //public AttackSpell(Mage m) : base(m)
    //{
    //    initValues();
    //}

    ////Player constructor
    //public AttackSpell(Sprite image) : base(image)
    //{
    //    initValues();
    //}

    //init values override
    protected override void initValues()
    {
        aggroScale = 10;
        statusScale = -10;
        baseSpellValue = 15;
        spellValue = baseSpellValue;
    }

    public override void cast(Mage enemy)
    {
        //First apply any self damage modifiers
        int temp = baseSpellValue;
        Events.HurtMage?.Invoke(spellValue, enemy);
    }
}
