using UnityEngine;

public class FireMage : Mage
{
    //Constructor
    public FireMage() : base()
    {

    }


    //Custom spellbook for fire mage
    protected override void initSpellBook()
    {
        base.initSpellBook();
        spellBook.Add(new IgniteSpell(this));
        spellBook.Add(new TwinFireballSpell(this));
        if (spellImages.Count > 0)
        {
            setSpellImages();
        }
    }
}
