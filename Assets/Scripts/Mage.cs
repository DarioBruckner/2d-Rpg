using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : magicUser
{
    
    public Mage() : base()
    {
        this.Charname = "The Mage";
    }
    public bool fireball(ref CharacterClass target)
    {
        if(this.drainMP(5))
        {
            double rawDamage = (this.magicalMight/target.magicalResistance) +1;
            System.Random rng = new System.Random();
            double crit = rng.Next(100) * ((this.agility / 100) + 1);
            if (crit > 90)
            {
                rawDamage *= 2;
            }
            int damage = (int)Math.Ceiling(rawDamage);
            target.takeMagicDamage(damage);
            return true;
        } else
        {
            return false;
        }
    }
    public bool thunder(ref CharacterClass target)
    {
        if (this.drainMP(8))
        {
            double rawDamage = (this.magicalMight / target.magicalResistance) + 1;
            System.Random rng = new System.Random();
            double crit = rng.Next(100) * ((this.agility / 100) + 1);
            if (crit > 50)
            {
                rawDamage *= 2;
            }
            int damage = (int)Math.Ceiling(rawDamage);
            target.takeMagicDamage(damage);
            return true;
        }
        else
        {
            return false;
        }
    }
}
