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
        DontDestroyOnLoad(gameObject);
        enemyClass = Instantiate(enemyClass);
        enemyClass.health = enemyClass.maxHealth;
        enemyClass.initSpellBook();

        CalculateMove();
    }

    public void CalculateMove()
    {
        if(playerSpellsUsed.Count > 0)
        {

        }
        else
        {
            spellToUse = enemyClass.attackSpell;
        }
    }
}
