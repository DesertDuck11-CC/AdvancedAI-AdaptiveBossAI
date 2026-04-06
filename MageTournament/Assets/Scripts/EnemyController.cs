using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    public Mage enemyClass;
    public List<Spell> playerSpellsUsed = new List<Spell>();

    public Spell spellToUse;

    void Awake()
    {
        enemyClass = Instantiate(enemyClass);
        enemyClass.health = enemyClass.maxHealth;
        enemyClass.initSpellBook();

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

    public void CalculateMove()
    {
        Dictionary<Spell, float> utilities = new Dictionary<Spell, float>();

        foreach (var spell in enemyClass.spellBook)
        {
            float score = EvaluateSpell(spell);
            utilities.Add(spell, score);
        }

        spellToUse = GetBestSpell(utilities);
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

            //case WeakenSpell:
            //    // Better if player is aggressive
            //    score += attackCount * 2.5f;
            //    break;

            //case VulnerableSpell:
            //    // Better if plan to attack soon
            //    score += 3f;
            //    break;

            //case ChargeSpell:
            //    // Better early or if player is passive
            //    score += (3 - attackCount) * 1.5f;
            //    break;

            //case BlizzardSpell:
            //    // Better if player is buffing or not defending
            //    score += buffCount * 2f;
            //    score += 4f;
            //    break;

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
