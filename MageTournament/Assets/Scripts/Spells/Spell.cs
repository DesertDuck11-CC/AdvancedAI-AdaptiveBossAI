using UnityEngine;
using UnityEngine.UI;

public class Spell
{
    //Member variables
    private Sprite buttonImage;
    private Canvas canvas;
    protected Mage owner;

    //Child classes init these values
    protected int aggroScale;   //Positive aggro: dealing damage                        negative aggro: defending
    protected int statusScale;  //Positive status: using aggro through buffs/debuffs    negative status: using aggro through straight numbers
    protected int spellValue;   //This is the numerical value of the spell effect, raw value means bigger numbers, status value means higher potency
    protected int baseSpellValue;
    protected string spellName;

    //npc spell constructor
    public Spell(Mage owner)
    {
        buttonImage = null;
        canvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        spellName = null;
    }

    //Player spell constructor |||| CURRENTLY NOT IN USE
    public Spell(Sprite image)
    {
        buttonImage = image;
        canvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        initUI();
    }

    //Function to set spell to belong to player
    public void assignPlayer(Sprite image)
    {
        buttonImage = image;
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
        baseSpellValue = 0;
        spellName = "none";
    }
}
