using UnityEngine;

public class FrostMage : Mage
{
    
    public FrostMage() : base()
    {
        spellBook.Add(new AttackSpell());
    }


    //Custom spellbook for frost mage
    protected override void initSpellBook()
    {
        base.initSpellBook();
        spellBook.Add(new BlizzardSpell());
        spellBook.Add(new Spell());
        if(spellImages.Count > 0)
        {
            setSpellImages();
        }
    }
}
