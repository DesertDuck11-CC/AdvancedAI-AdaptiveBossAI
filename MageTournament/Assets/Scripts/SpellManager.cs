using UnityEngine;

public class SpellManager : MonoBehaviour
{
    private Mage player;
    private Mage opponent;
    private bool playerTurn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindWithTag("Player").GetComponent<Mage>();
        playerTurn = false;
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
    public void castSpell(int spellID, Mage caster)
    {
        if(playerTurn)
        {
            Events.SpellCast?.Invoke(spellID, opponent);
        }
        else
        {
            Events.SpellCast?.Invoke(spellID, player);
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
