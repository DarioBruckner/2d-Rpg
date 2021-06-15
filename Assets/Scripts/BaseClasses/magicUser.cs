using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicUser : PlayerClass 
{               
                
    public MagicUser() : base()
    {
        this.n_maxHP = (int)Math.Ceiling((double)(this.n_maxHP * 0.8));
        this.n_maxMP = (int)Math.Ceiling((double)(this.n_maxMP * 1.5));
        this.n_stdStrength = (int)Math.Ceiling((double)(this.n_stdStrength * 0.8));
        this.n_stdAgility = (int)Math.Ceiling((double)(this.n_stdAgility * 1));
        this.n_stdVitality = (int)Math.Ceiling((double)(this.n_stdVitality * 0.8));
        this.n_stdMagicalMight = (int)Math.Ceiling((double)(this.n_stdMagicalMight * 3));
        this.n_stdMagicalResistance = (int)Math.Ceiling((double)(this.n_stdMagicalResistance * 1.2));
        this.resetStats();
    }
    public override void levelUp()
    {
        base.levelUp();
    }

    public override void attack(ref CharacterClass target)
    {
        double rawDamage = (this.n_strength / target.n_vitality) + 1;
        System.Random rng = new System.Random();
        double crit = rng.Next(100) * ((this.n_agility / 100) + 1);
        if (crit > 90)
        {
            rawDamage *= 2;
        }
        int damage = (int)Math.Ceiling(rawDamage);
        target.takePhysDamage(damage);
        int absMP = rng.Next(1, 6);
        if(target.drainMP(absMP))
        {
            this.regenerateMP(absMP);
        }
    }
}
