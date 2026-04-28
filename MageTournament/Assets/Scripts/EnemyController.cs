using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    public Mage enemyClass;
    public List<Spell> playerSpellsUsed = new List<Spell>();

    public Spell spellToUse;
    private Vector2 playerID;
    private Vector2 statusID;
    private SpellManager spellManager;

    void Awake()
    {
        enemyClass = Instantiate(enemyClass);
        enemyClass.health = enemyClass.maxHealth;
        enemyClass.initSpellBook();
        spellManager = GameObject.FindWithTag("SpellManager").GetComponent<SpellManager>();

        CalculateMove();
    }

    private void Update()
    {
        if (enemyClass.health < 0)
        {
            enemyClass.health = 0;
        }
    }

    public IEnumerator CastSpell()
    {
        yield return new WaitForSeconds(1);

        enemyClass.spellManager.castSpell(spellToUse, enemyClass);
    }

    //Builds player profile
    public void getHistory()
    {
        int aggro = 0;
        int status = 0;
        int index = 0;
        foreach (var spell in playerSpellsUsed)
        {
            aggro += spell.aggroScale;
            status += spell.statusScale;
            if(index >= playerSpellsUsed.Count -3)
            {
                aggro += spell.aggroScale;
                status += spell.statusScale;
            }
            index++;
        }
        playerID.x = aggro / playerSpellsUsed.Count;
        playerID.y = status / playerSpellsUsed.Count;
    }

    //Modifies player profile based on the current buffs/debuffs active
    public void checkStatus()
    {
        //Modify based on self statuses
        int ag = 0;
        foreach(Status s in enemyClass.currentEffects)
        {
            ag -= s.aggro;
        }
        if(enemyClass.currentEffects.Count > 0)
        {
            statusID.x = (ag / enemyClass.currentEffects.Count);
            statusID.y = Mathf.Min(10.0f, enemyClass.currentEffects.Count - 2);
        }

        //Modify based on player statuses
        ag = 0;
        int count = 0;
        foreach (Status s in spellManager.getOpponent(enemyClass).currentEffects)
        {
            ag -= s.seenAggro;
            count++;
        }
        if(count > 0)
        {
            statusID.x = statusID.x + (ag / count);
            statusID.y = statusID.y + Mathf.Max(-10.0f, count + 2);
        }
    }

    public void CalculateMove()
    {
        //checks if first turn of the game
        if(playerSpellsUsed.Count <= 0)
        {
            spellToUse = enemyClass.spellBook[0];
        }
        else
        {
            //Build the player profile based on their previous moves and the status effects the enemy is affected with
            getHistory();
            checkStatus();

            float smallestMag = 100.0f;
            Vector2 player = -(playerID + statusID);
            Vector2 test = new Vector2();
            foreach (Spell s in enemyClass.spellBook)
            {
                test = new Vector2(s.aggroScale, s.statusScale);
                if ((player - test).magnitude < smallestMag)
                {
                    spellToUse = s;
                    smallestMag = (player - test).magnitude;
                }
            }
        }
        

        //Dictionary<Spell, float> utilities = new Dictionary<Spell, float>();

        /*foreach (var spell in enemyClass.spellBook)
        {
            float score = EvaluateSpell(spell);
            utilities.Add(spell, score);
        }*/

        //spellToUse = GetBestSpell(utilities);
    }










    int CountRecent<T>() where T : Spell
    {
        int count = 0;

        foreach (var spell in playerSpellsUsed)
        {
            if(spell is T) 
                count++;
        }

        return count;
    }



    float EvaluateSpell(Spell spell)
    {
        float score = 0f;

        int attackCount = CountRecent<AttackSpell>();
        int defendCount = CountRecent<DefenseSpell>();
        int buffCount = CountRecent<ChargeSpell>();

        float enemyHealthPercent = (float)enemyClass.health / enemyClass.maxHealth;

        switch (spell)
        {
            case AttackSpell:
                score += 5f;

                // Better if player is defending a lot, attacks are weaker
                score -= defendCount * 1.5f;

                score += enemyClass.block / 2;

                break;

            case DefenseSpell:
                // Better if player attacks a lot, defend is valuable
                score += attackCount * 4f;

                // Better if low HP
                score += (1f - enemyHealthPercent) * 3f;

                break;

            case WeakenSpell:
                // Better if player is aggressive
                score += attackCount * 2.5f;
                break;

            case VulnerableSpell:
                // Better if plan to attack soon
                score += 3f;
                break;

            case ChargeSpell:
                // Better early or if player is passive
                score += (3 - attackCount) * 1.5f;
                if(enemyClass.isCharge())
                {
                    score = 0;
                }
                break;

            case BlizzardSpell:
                // Better if player is defending
                score += defendCount * 2f;
                score += 4f;
                break;

            case IceWallSpell:
                // Emergency defense
                score += attackCount * 3f;
                score += (1f - enemyHealthPercent) * 8f;
                break;
        }

        return score;
    }

    Spell GetBestSpell(Dictionary<Spell, float> utilities)
    {
        float bestScore = float.MinValue;
        Spell bestSpell = null;

        foreach (var pair in utilities)
        {
            if (pair.Value > bestScore)
            {
                bestScore = pair.Value;
                bestSpell = pair.Key;
            }
        }

        return bestSpell;
    }
}
