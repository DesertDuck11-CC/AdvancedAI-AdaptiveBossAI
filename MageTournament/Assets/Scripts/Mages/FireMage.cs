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
        spellBook.Add(new IgniteSpell());
        spellBook.Add(new TwinFireballSpell());
        if (spellImages.Count > 0)
        {
            setSpellImages();
        }
    }
}
