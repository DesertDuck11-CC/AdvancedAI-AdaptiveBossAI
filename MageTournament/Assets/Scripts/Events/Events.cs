using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Events
{
    public static Action<Spell, Mage> SpellCast; //This is called by the SpellManager when the player or enemy takes an action
    public static Action<Status, Mage> StatusApplied;  //This is called when a status effect is applied to Mage
    public static Action<int, Mage> HurtMage;

    public static Action<Mage> NextTurn;  //This is called when the turn rolls over to the player


}
