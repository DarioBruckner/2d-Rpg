using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicUser : PlayerClass
{
    public magicUser() : base()
    {
        this.maxHP = (int)Math.Ceiling((double)(this.maxHP * 0.8));
        this.maxMP = (int)Math.Ceiling((double)(this.maxMP * 1.5));
        this.stdStrength = (int)Math.Ceiling((double)(this.stdStrength * 0.8));
        this.stdAgility = (int)Math.Ceiling((double)(this.stdAgility * 1));
        this.stdVitality = (int)Math.Ceiling((double)(this.stdVitality * 0.8));
        this.stdMagicalMight = (int)Math.Ceiling((double)(this.stdMagicalMight * 3));
        this.stdMagicalResistance = (int)Math.Ceiling((double)(this.stdMagicalResistance * 1.2));
        this.resetStats();
    }
}
