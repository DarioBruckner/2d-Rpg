using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : CharacterClass
{

   
    public Thief() : base()
    {
        this.Charname = "The Thief";
        maxHP = (int)Math.Ceiling((double)(maxHP * 1));
        maxMP = (int)Math.Ceiling((double)(maxMP * 0.6));
        stdStrength = (int)Math.Ceiling((double)(stdStrength * 1.2));
        stdAgility = (int)Math.Ceiling((double)(stdAgility * 1.5));
        stdVitality = (int)Math.Ceiling((double)(stdVitality * 1));
        stdMagicalMight = (int)Math.Ceiling((double)(stdMagicalMight * 0));
        stdMagicalResistance = (int)Math.Ceiling((double)(stdMagicalResistance * 1));
        resetStats();
    }
}
