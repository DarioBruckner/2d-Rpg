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

    public bool multiSlash(ref CharacterClass target)
    {
        if(this.drainMP(3))
        {
            System.Random rng = new System.Random();
            int attacks = rng.Next(1, 6);
            for (int i = 0; i < attacks; i++)
            {
                double rawDamage = ((this.strength * 0.75) / target.vitality) + 1;
                double crit = rng.Next(100) * ((this.agility / 100) + 1);
                if (crit > 80)
                {
                    rawDamage *= 2;
                }
                int damage = (int)Math.Ceiling(rawDamage);
                target.takePhysDamage(damage);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
