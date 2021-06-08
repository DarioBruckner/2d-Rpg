using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerClass
{

    
    public Warrior() : base()
    {
        this.s_name = "The Warrior";
        this.n_maxHP = (int)Math.Ceiling((double)(this.n_maxHP * 1.2));
        this.n_maxMP = (int)Math.Ceiling((double)(this.n_maxMP * 0.4));
        this.n_stdStrength = (int)Math.Ceiling((double)(this.n_stdStrength * 1.6));
        this.n_stdAgility = (int)Math.Ceiling((double)(this.n_stdAgility * 0.4));
        this.n_stdVitality = (int)Math.Ceiling((double)(this.n_stdVitality * 1.6));
        this.n_stdMagicalMight = (int)Math.Ceiling((double)(this.n_stdMagicalMight * 0));
        this.n_stdMagicalResistance = (int)Math.Ceiling((double)(this.n_stdMagicalResistance * 0.6));
        this.resetStats();
    }
    public bool heavySmash(ref CharacterClass target)
    {
        if (this.drainMP(2))
        {
            double rawDamage = (this.n_strength / (target.n_vitality / 2)) + 1;
            System.Random rng = new System.Random();
            double crit = rng.Next(100) * ((this.n_agility / 100) + 1);
            if (crit > 90)
                rawDamage *= 2;

            int damage = (int)Math.Ceiling(rawDamage);
            target.takePhysDamage(damage);
            return true;
        }
        else
            return false;
    }
}
