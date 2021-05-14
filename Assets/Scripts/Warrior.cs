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
    public bool heavySmash(ref CharacterClass target)
    {
        if (this.drainMP(2))
        {
            double rawDamage = (this.strength / (target.vitality / 2)) + 1;
            System.Random rng = new System.Random();
            double crit = rng.Next(100) * ((this.agility / 100) + 1);
            if (crit > 90)
            {
                rawDamage *= 2;
            }
            int damage = (int)Math.Ceiling(rawDamage);
            target.takePhysDamage(damage);
            return true;
        }
        else
        {
            return false;
        }
    }
}
