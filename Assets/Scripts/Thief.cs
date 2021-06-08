using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : PlayerClass
{

   
    public Thief() : base()
    {
        this.s_name = "The Thief";
        this.n_maxHP = (int)Math.Ceiling((double)(this.n_maxHP * 1));
        this.n_maxMP = (int)Math.Ceiling((double)(this.n_maxMP * 0.6));
        this.n_stdStrength = (int)Math.Ceiling((double)(this.n_stdStrength * 1.2));
        this.n_stdAgility = (int)Math.Ceiling((double)(this.n_stdAgility * 1.5));
        this.n_stdVitality = (int)Math.Ceiling((double)(this.n_stdVitality * 1));
        this.n_stdMagicalMight = (int)Math.Ceiling((double)(this.n_stdMagicalMight * 0));
        this.n_stdMagicalResistance = (int)Math.Ceiling((double)(this.n_stdMagicalResistance * 1));
        this.resetStats();
    }

    public bool multiSlash(ref CharacterClass target)
    {
        if(this.drainMP(3))
        {
            //generates random amount of Attacks between 1 and 6
            System.Random rng = new System.Random();
            int attacks = rng.Next(1, 6);
            for (int i = 0; i < attacks; i++)
            {
                double rawDamage = ((this.n_strength * 0.75) / target.n_vitality) + 1;
                double crit = rng.Next(100) * ((this.n_agility / 100) + 1);
                if (crit > 80)
                   rawDamage *= 2;

                int damage = (int)Math.Ceiling(rawDamage);
                target.takePhysDamage(damage);
            }
            return true; //Attack was successful
        }
        else
            return false; //Error: Not enough Magic Power
    }
}
