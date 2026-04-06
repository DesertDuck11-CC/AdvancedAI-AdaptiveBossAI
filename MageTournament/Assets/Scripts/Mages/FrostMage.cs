using UnityEngine;

public class FrostMage : Mage
{
    //Constructor
    public FrostMage() : base()
    {

    }


    //Custom spellbook for frost mage
    protected override void initSpellBook()
    {
        base.initSpellBook();
        spellBook.Add(new BlizzardSpell(this));
        spellBook.Add(new IceWallSpell(this));
        if(spellImages.Count > 0)
        {
            setSpellImages();
        }
    }
}
