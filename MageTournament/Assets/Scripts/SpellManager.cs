using UnityEngine;
using UnityEngine.Rendering.UI;

public class SpellManager : MonoBehaviour
{
    private Mage player;
    private Mage opponent;
    public bool playerTurn;

    [SerializeField] PlayerUI playerUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>().playerClass;
        player.spellManager = this;
        opponent = GameObject.FindWithTag("Enemy").GetComponent<EnemyController>().enemyClass;
        opponent.spellManager = this;

        playerTurn = true;

        // Initialize player UI vars
        playerUI.player = player;
        playerUI.enemy = opponent;
        playerUI.spellManager = this;
        playerUI.InitButtonText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Binding/Unbinding Events
    private void OnEnable()
    {
        Events.NextTurn += nextTurn;
        Events.HurtMage += damageMage;
    }
    private void OnDisable()
    {
        Events.NextTurn -= nextTurn;
        Events.HurtMage -= damageMage;
    }



    //Called by both player controller and AI controller to cast the proper spell against the correct enemy
    public void castSpell(Spell spell, Mage caster)
    {
        if(playerTurn)
        {
            //Events.SpellCast?.Invoke(spell, opponent);
            player.cast(spell, opponent);
            GameObject.FindWithTag("Enemy").GetComponent<EnemyController>().playerSpellsUsed.Add(spell);
            GameObject.FindWithTag("Enemy").GetComponent<EnemyController>().CalculateMove();
        }
        else
        {
            //Events.SpellCast?.Invoke(spell, player);
            opponent.cast(spell, player);
        }
    }

    //Function casts spell for the current mage and then rotates turn
    public void nextTurn(Mage m)
    {
        if(playerTurn)
        {
            playerTurn = false;
        }
        else
        {
            playerTurn = true;
        }
    }
    
    public void damageMage(int dmg, Mage m)
    {
        m.damage(dmg);
    }
}
