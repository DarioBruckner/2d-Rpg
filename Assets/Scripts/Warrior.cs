using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerClass
{

    
    public Warrior():base()
    {
        this.Charname = "The Warrior";
        this.maxHP = (int)Math.Ceiling((double)(this.maxHP * 1.2));
        this.maxMP = (int)Math.Ceiling((double)(this.maxMP * 0.4));
        this.stdStrength = (int)Math.Ceiling((double)(this.stdStrength * 1.6));
        this.stdAgility = (int)Math.Ceiling((double)(this.stdAgility * 0.4));
        this.stdVitality = (int)Math.Ceiling((double)(this.stdVitality * 1.6));
        this.stdMagicalMight = (int)Math.Ceiling((double)(this.stdMagicalMight * 0));
        this.stdMagicalResistance = (int)Math.Ceiling((double)(this.stdMagicalResistance * 0.6));
        this.resetStats();
    }
}
