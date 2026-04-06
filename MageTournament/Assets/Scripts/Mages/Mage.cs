using UnityEngine;
using System.Collections.Generic;

public class Mage : ScriptableObject
{
    //Member vars
    [HideInInspector] public List<Spell> spellBook = new List<Spell>();
    public List<Sprite> spellImages = new List<Sprite>();
    private List<Status> statusEffects = new List<Status>();
    [HideInInspector] public SpellManager spellManager;
    
    [HideInInspector] public int health;
    [HideInInspector] public int block;

    [Header("Health")]
    public int maxHealth;

    [Header("Class Name")]
    public string className;

    [Header("Spells")]
    public Spell attackSpell;
    public Spell defenseSpell;
    public Spell weakenSpell;
    public Spell vulnerableSpell;
    public Spell chargeSpell;

    //Constructors
    //public Mage(SpellManager sm)
    //{
    //    spellManager = sm;
    //    maxHealth = 100;
    //    health = maxHealth;
    //    block = 0;
    //    initSpellBook();
    //    setSpellManager();
    //}

    //public Mage()
    //{
    //    maxHealth = 100;
    //    health = maxHealth;
    //    block = 0;
    //    initSpellBook();
    //    setSpellManager();
    //}

    ////Copy constructors
    //public Mage(List<Spell> book, List<Sprite> images)
    //{
    //    spellBook = book;
    //    maxHealth = 100;
    //    health = maxHealth;
    //    spellImages = images;
    //    block = 0;
    //    setSpellManager();
    //}

    //public Mage(List<Spell> book)
    //{
    //    spellBook = book;
    //    maxHealth = 100;
    //    health = maxHealth;
    //    block = 0;
    //    setSpellManager();
    //}

    //Binding/Unbinding events
    private void OnEnable()
    {
        //Events.SpellCast += cast;
    }
    private void OnDisable()
    {
        //Events.SpellCast -= cast;
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
    public virtual void initSpellBook()
    {
        //Empty spell book list to be safe
        spellBook.Clear();

        // Assign spell owners
        attackSpell.assignPlayer(this);
        defenseSpell.assignPlayer(this);
        weakenSpell.assignPlayer(this);
        vulnerableSpell.assignPlayer(this);
        chargeSpell.assignPlayer(this);

        //Add the basic spell additions        
        spellBook.Add(attackSpell);
        spellBook.Add(defenseSpell);
        spellBook.Add(weakenSpell);
        spellBook.Add(vulnerableSpell);
        spellBook.Add(chargeSpell);
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
    public void cast(Spell spell, Mage enemy)
    {
        if (enemy == this)
        {
            //Do nothing
        }
        else
        {
            spell.cast(enemy);
            Events.NextTurn?.Invoke(this);
        }
    }


    //Function called for damage modifiers as caster
    public void checkSelfStatus(int baseDamage)
    {
        //gameObject.GetComponents<Status>(statusEffects);
        //if (statusEffects.Count > 0)
        //{
        //    //Check for damage modifiers

        //}
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
