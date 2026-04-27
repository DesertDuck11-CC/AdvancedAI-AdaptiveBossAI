using UnityEngine;
using System.Collections.Generic;
using System.Linq;

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

    public List<Status> currentEffects = new List<Status>();

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
        Events.NextTurn += nextTurn;
    }
    private void OnDisable()
    {
        //Events.SpellCast -= cast;
        Events.NextTurn -= nextTurn;
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
            //check if spell has been charged
            if(isCharge())
            {
                spell.spellValue *= 2;
            }
            spell.cast(enemy);
            Events.NextTurn?.Invoke(this);
        }
    }

    public bool isCharge()
    {
        foreach (Status s in currentEffects)
        {
            switch(s)
            {
                case (Charge):
                    return true;
            }
        }
        return false;
    }

    //Function called for damage modifiers as caster
    public int checkSelfStatus(int baseDamage)
    {
        int def = baseDamage;
        foreach(Status s in currentEffects)
        {
            switch(s)
            {
                case (WeakenDebuff):
                    def = (int)(def * ((100.0f - s.potency) / 100.0f));
                    Debug.Log(def);
                    break;
                default:
                    //do nothing
                    break;
            }
        }
        return def;
    }

    //Function called for damage modifiers as enemy
    public int checkEnemyStatus(int newDamage)
    {
        int def = newDamage;
        foreach (Status s in currentEffects)
        {
            switch (s)
            {
                case (VulnerableDebuff):
                    def = (int)(def * ((s.potency+100.0f) / 100.0f));
                    break;
                case (IgniteDebuff):
                    this.addStatus(new BurningDebuff(this));
                    break;
                default:
                    //do nothing
                    break;
            }
        }
        return def;
    }

    //function called to damage self
    public void damage(int damage)
    {
        int mod = spellManager.getOpponent(this).checkSelfStatus(damage);

        block = block - checkEnemyStatus(mod);
        if(block <= 0)
        {
            //check for brittle status
            if(currentEffects.OfType<BrittleDebuff>().Any())
            {
                health -= 5;
            }
            health -= Mathf.Abs(block);
            block = 0;
        }
    }

    //function called to add block
    public void defend(int b)
    {
        block += b;
    }

    public void addStatus(Status s)
    {
        if(currentEffects.OfType<Counterspell>().Any() && !s.positive)
        {
            foreach(Status sa in currentEffects)
            {
                if(sa is Counterspell)
                {
                    currentEffects.Remove(sa);
                    return;
                }
            }
        }
        else
        {
            currentEffects.Add(s);
        }
    }

    //Called when the turn changes
    public void nextTurn(Mage m)
    {
        if(m == this)
        {
            foreach (Status s in currentEffects)
            {
                if (s.nextTurn())
                {
                    currentEffects.Remove(s);
                }
            }
        }
    }
}
