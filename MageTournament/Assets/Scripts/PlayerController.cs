using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Mage playerClass;
    [SerializeField] private List<Sprite> spellImages = new List<Sprite>();

    void Awake()
    {
        playerClass = Instantiate(playerClass);
        playerClass.health = playerClass.maxHealth;
        playerClass.initSpellBook();
    }

    void Update()
    {
        if(playerClass.health < 0)
        {
            playerClass.health = 0;
        }
    }
}
