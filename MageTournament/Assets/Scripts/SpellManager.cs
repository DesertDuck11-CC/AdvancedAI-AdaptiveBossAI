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
        playerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function casts spell for the current mage and then rotates turn
    public void cast(Spell spell)
    {
        if(playerTurn)
        {
            spell.cast(opponent);
            player.endTurn();
            playerTurn = false;
        }
        else
        {
            spell.cast(player);
            opponent.endTurn();
            playerTurn = true;
        }
    }
    
}
