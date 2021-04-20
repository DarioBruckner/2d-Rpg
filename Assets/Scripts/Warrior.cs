using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : CharacterClass
{
    public Warrior():base()
    {
        maxHP = (int)Math.Ceiling((double)(maxHP * 1.2));
        maxMP = (int)Math.Ceiling((double)(maxMP * 0.4));
        stdStrength = (int)Math.Ceiling((double)(stdStrength * 1.6));
        stdAgility = (int)Math.Ceiling((double)(stdAgility * 0.4));
        stdVitality = (int)Math.Ceiling((double)(stdVitality * 1.6));
        stdMagicalMight = (int)Math.Ceiling((double)(stdMagicalMight * 0));
        stdMagicalResistance = (int)Math.Ceiling((double)(stdMagicalResistance * 0.6));
        resetStats();
    }
}
