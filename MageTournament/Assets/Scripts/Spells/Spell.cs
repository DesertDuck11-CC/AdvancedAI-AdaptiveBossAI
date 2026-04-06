using UnityEngine;
using UnityEngine.UI;

public class Spell
{
    //Member variables
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

    //Player spell constructor |||| CURRENTLY NOT IN USE
    public Spell(Sprite image)
    {
        buttonImage = image;
        canvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        isPlayer = true;
        initUI();
    }

    //Function to set spell to belong to player
    public void assignPlayer(Sprite image)
    {
        buttonImage = image;
        isPlayer = true;
        initUI();
    }

    //Creates button and assigns it to canvas
    private void initUI()
    {

    }

    //Function to set button image
    public void setImage(Sprite image)
    {
        buttonImage = image;
    }


    //Call this to cast the spell if the spell affects the same mage
    public virtual void cast()
    {

    }

    //Call this to cast the spell against the enemy
    public virtual void cast(Mage enemy)
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
}
