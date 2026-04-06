using UnityEngine;
using System.Collections.Generic;

public class Mage : MonoBehaviour
{
    //Member vars
    public List<Spell> spellBook = new List<Spell>();
    public List<Sprite> spellImages = new List<Sprite>();
    private List<Status> statusEffects = new List<Status>();
    protected SpellManager spellManager;
    protected int health;
    protected int block;
    protected int maxHealth;

    //Constructors
    public Mage(SpellManager sm)
    {
        spellManager = sm;
        maxHealth = 100;
        block = 0;
        initSpellBook();
        setSpellManager();
    }

    public Mage()
    {
        maxHealth = 100;
        block = 0;
        initSpellBook();
        setSpellManager();
    }

    //Copy constructors
    public Mage(List<Spell> book, List<Sprite> images)
    {
        spellBook = book;
        maxHealth = 100;
        spellImages = images;
        block = 0;
        setSpellManager();
    }

    public Mage(List<Spell> book)
    {
        spellBook = book;
        maxHealth = 100;
        block = 0;
        setSpellManager();
    }

    //Binding/Unbinding events
    private void OnEnable()
    {
        Events.SpellCast += cast;
    }
    private void OnDisable()
    {
        Events.SpellCast -= cast;
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
        spellBook.Add(new AttackSpell(this));
        spellBook.Add(new DefenseSpell(this));
        spellBook.Add(new WeakenSpell(this));
        spellBook.Add(new VulnerableSpell(this));
        spellBook.Add(new ChargeSpell(this));
    }

    //Function sets button images for each spell in the order: Attack->Defense->Weaken->Vulnerable->Charge->Custom1->Custom2
    protected void setSpellImages()
    {
        for(int i = 0; i < spellImages.Count; i++)
        {
            spellBook[i].setImage(spellImages[i]);
        }
    }


    //function called by player to cast the spell
    public void cast(int i, Mage enemy)
    {
        if (enemy == this)
        {
            //Do nothing
        }
        else
        {
            spellBook[i].cast(enemy);
            Events.NextTurn?.Invoke(this);
        }
    }


    //Function called for damage modifiers as caster
    public void checkSelfStatus(int baseDamage)
    {
        gameObject.GetComponents<Status>(statusEffects);
        if (statusEffects.Count > 0)
        {
            //Check for damage modifiers

        }
    }
    //Function called for damage modifiers as enemy
    public void checkEnemyStatus(int newDamage)
    {

    }

    //function called to damage self
    public void damage(int damage)
    {
        

        block = block - damage;
        if(block <= 0)
        {
            
            health -= Mathf.Abs(block);
            block = 0;
        }
    }

    //function called to add block
    public void defend(int b)
    {
        block += b;
    }
}
