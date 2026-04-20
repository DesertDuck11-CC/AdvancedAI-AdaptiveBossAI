using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class SpellManager : MonoBehaviour
{
    private Mage player;
    private Mage opponent;
    public bool playerTurn;

    [SerializeField] PlayerUI playerUI;

    private EnemyController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>().playerClass;
        player.spellManager = this;
        controller = GameObject.FindWithTag("Enemy").GetComponent<EnemyController>();
        opponent = controller.enemyClass;
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
        //caster.block = 0;

        if (playerTurn)
        {
            //Events.SpellCast?.Invoke(spell, opponent);
            caster.cast(spell, opponent);
            controller.playerSpellsUsed.Add(spell);

            if(controller.playerSpellsUsed.Count > 3)
            {
                controller.playerSpellsUsed.RemoveAt(0);
            }

            controller.StartCoroutine(controller.CastSpell());
        }
        else
        {
            //Events.SpellCast?.Invoke(spell, player);
            caster.cast(spell, player);
            controller.CalculateMove();
        }

        if (player.health <= 0)
        {
            GameState.playerWon = false;
            StartCoroutine(EndGame());
        }
        else if (opponent.health <= 0)
        {
            GameState.playerWon = true;
            StartCoroutine(EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("EndScreen");
    }

    //Function casts spell for the current mage and then rotates turn
    public void nextTurn(Mage m)
    {
        Debug.Log("NExt");
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

    //Easy function to get opposing mage
    public Mage getOpponent(Mage m)
    {
        if(m == player)
        {
            return opponent;
        }
        else
        {
            return player;
        }
    }
}
