using UnityEngine;

public class SpellManager : MonoBehaviour
{
    private Mage player;
    private Mage opponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
