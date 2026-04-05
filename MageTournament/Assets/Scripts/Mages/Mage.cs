using UnityEngine;
using System.Collections.Generic;

public class Mage
{
    //Member vars
    public List<Spell> spellBook = new List<Spell>();
    public List<Sprite> spellImages = new List<Sprite>();
    protected SpellManager spellManager;
    protected int health;
    protected int maxHealth;

    //Constructors
    public Mage(SpellManager sm)
    {
        spellManager = sm;
        maxHealth = 100;
        initSpellBook();
        setSpellManager();
    }

    public Mage()
    {
        maxHealth = 100;
        initSpellBook();
        setSpellManager();
    }

    //Copy constructor
    public Mage(List<Spell> book, List<Sprite> images)
    {
        spellBook = book;
        maxHealth = 100;
        spellImages = images;
        setSpellManager();
    }

    //Call this function on start to connect the spell manager to the mage class
    protected void setSpellManager()
    {
        spellManager = GameObject.FindWithTag("SpellManager").GetComponent<SpellManager>();
    }

    //Call this function to reset player's health
    public void resetStats()
    {
        health = maxHealth;
    }

    //Function initializes spell book values.  Each subclass adds on to this list with their custom spells
    protected virtual void initSpellBook()
    {
        //empty spell book list to be safe
        spellBook.Clear();
        //Add the basic spell additions
        spellBook.Add(new AttackSpell());
        spellBook.Add(new DefenseSpell());
        spellBook.Add(new WeakenSpell());
        spellBook.Add(new VulnerableSpell());
        spellBook.Add(new ChargeSpell());
    }

    //Function sets button images for each spell in the order: Attack->Defense->Weaken->Vulnerable->Charge->Custom1->Custom2
    protected void setSpellImages()
    {
        for(int i = 0; i < spellImages.Count; i++)
        {
            spellBook[i].setImage(spellImages[i]);
        }
    }
}
