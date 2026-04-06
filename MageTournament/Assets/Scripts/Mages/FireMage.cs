using UnityEngine;

[CreateAssetMenu(menuName = "Mages/Fire Mage", fileName = "Fire Mage")]
public class FireMage : Mage
{
    public Spell twinFireballSpell;
    public Spell igniteSpell;

    //Constructor
    //public FireMage() : base()
    //{

    //}


    //Custom spellbook for fire mage
    public override void initSpellBook()
    {
        base.initSpellBook();

        twinFireballSpell.assignPlayer(this);
        igniteSpell.assignPlayer(this);

        spellBook.Add(twinFireballSpell);
        spellBook.Add(igniteSpell);
        if (spellImages.Count > 0)
        {
            setSpellImages();
        }
    }
}
