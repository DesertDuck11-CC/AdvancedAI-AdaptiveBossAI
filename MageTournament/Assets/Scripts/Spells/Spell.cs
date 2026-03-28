using UnityEngine;
using UnityEngine.UI;

public class Spell
{
    private Sprite buttonImage;
    private Canvas canvas;
    protected bool isPlayer;    //True if spell belongs to player, false if belongs to enemy

    //Child classes init these values
    protected int aggroScale;   //Positive aggro: dealing damage                        negative aggro: defending
    protected int statusScale;  //Positive status: using aggro through buffs/debuffs    negative status: using aggro through straight numbers
    protected int spellValue;   //This is the numerical value of the spell effect, raw value means bigger numbers, status value means higher potency
    protected string spellName;

    //npc spell constructor
    public Spell()
    {
        buttonImage = null;
        canvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        isPlayer = false;
        spellName = null;
    }

    //Player spell constructor
    public Spell(Sprite image)
    {
        buttonImage = image;
        canvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        isPlayer = true;
        initUI();
    }

    //Creates button and assigns it to canvas
    private void initUI()
    {

    }

    //Initializes member variables
    protected virtual void initValues()
    {
        spellValue = 0;
        statusScale = 0;
        aggroScale = 0;
        spellName = "none";
    }

    //Call this to cast the spell
    public void cast()
    {

    }

}
