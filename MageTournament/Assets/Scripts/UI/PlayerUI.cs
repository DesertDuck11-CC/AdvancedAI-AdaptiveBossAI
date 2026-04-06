using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("Spell Buttons")]
    [SerializeField] SpellButton attackSpell;
    [SerializeField] SpellButton defenseSpell;
    [SerializeField] SpellButton weakenSpell;
    [SerializeField] SpellButton vulnerableSpell;
    [SerializeField] SpellButton chargeSpell;
    [SerializeField] SpellButton uniqueSpell1;
    [SerializeField] SpellButton uniqueSpell2;

    [Header("Intent Text")]
    [SerializeField] TMP_Text intentText;

    [Header("Player Info")]
    [SerializeField] TMP_Text playerName;
    [SerializeField] TMP_Text playerHealthText;
    [SerializeField] Image playerHealthFill;
    [SerializeField] GameObject playerShield;
    [SerializeField] TMP_Text playerShieldText;

    [Header("Enemy Info")]
    [SerializeField] TMP_Text enemyName;
    [SerializeField] TMP_Text enemyHealthText;
    [SerializeField] Image enemyHealthFill;
    [SerializeField] GameObject enemyShield;
    [SerializeField] TMP_Text enemyShieldText;

    [HideInInspector] public Mage player;
    [HideInInspector] public Mage enemy;
    [HideInInspector] public SpellManager spellManager;

    public void InitButtonText()
    {
        attackSpell.text.text = player.attackSpell.spellName;
        attackSpell.spell = player.attackSpell;
        defenseSpell.text.text = player.defenseSpell.spellName;
        defenseSpell.spell = player.defenseSpell;
        weakenSpell.text.text = player.weakenSpell.spellName;
        weakenSpell.spell = player.weakenSpell;
        vulnerableSpell.text.text = player.vulnerableSpell.spellName;
        vulnerableSpell.spell = player.vulnerableSpell;
        chargeSpell.text.text = player.chargeSpell.spellName;
        chargeSpell.spell = player.chargeSpell;

        switch (player)
        {
            case FireMage fireMage:
                uniqueSpell1.text.text = fireMage.twinFireballSpell.spellName;
                uniqueSpell1.spell = fireMage.twinFireballSpell;
                uniqueSpell2.text.text = fireMage.igniteSpell.spellName;
                uniqueSpell2.spell = fireMage.igniteSpell;
                break;
            case FrostMage frostMage:
                uniqueSpell1.text.text = frostMage.blizzardSpell.spellName;
                uniqueSpell1.spell = frostMage.blizzardSpell;
                uniqueSpell2.text.text = frostMage.iceWallSpell.spellName;
                uniqueSpell2.spell = frostMage.iceWallSpell;
                break;
            default:
                break;
        }

        playerName.text = player.className;
        enemyName.text = enemy.className;

        attackSpell.button.onClick.AddListener(() => castSpell(attackSpell.spell));
        defenseSpell.button.onClick.AddListener(() => castSpell(defenseSpell.spell));
        weakenSpell.button.onClick.AddListener(() => castSpell(weakenSpell.spell));
        vulnerableSpell.button.onClick.AddListener(() => castSpell(vulnerableSpell.spell));
        chargeSpell.button.onClick.AddListener(() => castSpell(chargeSpell.spell));
        uniqueSpell1.button.onClick.AddListener(() => castSpell(uniqueSpell1.spell));
        uniqueSpell2.button.onClick.AddListener(() => castSpell(uniqueSpell2.spell));
    }

    private void Update()
    {
        // Button interactibility
        attackSpell.button.interactable = spellManager.playerTurn;
        defenseSpell.button.interactable = spellManager.playerTurn;
        weakenSpell.button.interactable = spellManager.playerTurn;
        vulnerableSpell.button.interactable = spellManager.playerTurn;
        chargeSpell.button.interactable = spellManager.playerTurn;
        uniqueSpell1.button.interactable = spellManager.playerTurn;
        uniqueSpell2.button.interactable = spellManager.playerTurn;

        // Update health UI
        playerHealthText.text = $"{player.health}/{player.maxHealth}";
        playerHealthFill.fillAmount = (float)player.health / (float)player.maxHealth;

        enemyHealthText.text = $"{enemy.health}/{enemy.maxHealth}";
        enemyHealthFill.fillAmount = (float)enemy.health / (float)enemy.maxHealth;

        // Update Shield UI
        playerShield.SetActive(player.block > 0);
        playerShieldText.text = $"{player.block}";

        enemyShield.SetActive(enemy.block > 0);
        enemyShieldText.text = $"{enemy.block}";
    }

    private void castSpell(Spell spell)
    {
        spellManager.castSpell(spell, player);
    }
}
