using UnityEngine;

[CreateAssetMenu(menuName = "Mages/Frost Mage", fileName = "Frost Mage")]
public class FrostMage : Mage
{
    public Spell blizzardSpell;
    public Spell iceWallSpell;

    //Constructor
    //public FrostMage() : base()
    //{

    //}


    //Custom spellbook for frost mage
    public override void initSpellBook()
    {
        base.initSpellBook();

        blizzardSpell.assignPlayer(this);
        iceWallSpell.assignPlayer(this);

        spellBook.Add(blizzardSpell);
        spellBook.Add(iceWallSpell);
        if(spellImages.Count > 0)
        {
            setSpellImages();
        }
    }
}
