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


    
}
