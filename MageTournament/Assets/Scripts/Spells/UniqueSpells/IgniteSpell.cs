using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Fire Mage/Ignite Spell", fileName = "Ignite Spell")]
public class IgniteSpell : Spell
{
    //NPC constructor
    //public IgniteSpell(Mage m) : base(m)
    //{
    //    initValues();
    //}

    ////Player constructor
    //public IgniteSpell(Sprite image) : base(image)
    //{
    //    initValues();
    //}

    //init values override
    protected override void initValues()
    {
        aggroScale = 5;
        statusScale = 8;
        spellValue = 5;  //Applies 3-turn buff to self that makes all damaging spells apply burning (5 DOT for 4 turns)
    }

    public override void cast(Mage enemy)
    {
        IgniteDebuff ig = new IgniteDebuff(enemy);
        enemy.addStatus(ig);
    }
}
