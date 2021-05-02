using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : PlayerClass
{

   
    public Thief() : base()
    {
        this.Charname = "The Thief";
        this.maxHP = (int)Math.Ceiling((double)(this.maxHP * 1));
        this.maxMP = (int)Math.Ceiling((double)(this.maxMP * 0.6));
        this.stdStrength = (int)Math.Ceiling((double)(this.stdStrength * 1.2));
        this.stdAgility = (int)Math.Ceiling((double)(this.stdAgility * 1.5));
        this.stdVitality = (int)Math.Ceiling((double)(this.stdVitality * 1));
        this.stdMagicalMight = (int)Math.Ceiling((double)(this.stdMagicalMight * 0));
        this.stdMagicalResistance = (int)Math.Ceiling((double)(this.stdMagicalResistance * 1));
        this.resetStats();
    }
}
