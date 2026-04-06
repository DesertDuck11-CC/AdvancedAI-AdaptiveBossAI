using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    public Mage enemyClass;
    private List<Spell> playerSpellsUsed = new List<Spell>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Call this when the player selects their mage class
    void updateClass(Mage m)
    {
        enemyClass = new Mage(m.spellBook);
    }
}
