using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicUser : PlayerClass
{
    public magicUser() : base()
    {
        maxHP = (int)Math.Ceiling((double)(maxHP * 0.8));
        maxMP = (int)Math.Ceiling((double)(maxMP * 1.5));
        stdStrength = (int)Math.Ceiling((double)(stdStrength * 0.8));
        stdAgility = (int)Math.Ceiling((double)(stdAgility * 1));
        stdVitality = (int)Math.Ceiling((double)(stdVitality * 0.8));
        stdMagicalMight = (int)Math.Ceiling((double)(stdMagicalMight * 3));
        stdMagicalResistance = (int)Math.Ceiling((double)(stdMagicalResistance * 1.2));
        resetStats();
    }
}
