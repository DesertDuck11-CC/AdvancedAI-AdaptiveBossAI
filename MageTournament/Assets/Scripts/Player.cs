using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] public Mage playerClass;
    [SerializeField] private List<Sprite> spellImages = new List<Sprite>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        updateClass(new FireMage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Call this when the player selects their mage class
    void updateClass(Mage m)
    {
        playerClass = new Mage(m.spellBook, spellImages);
    }


}
