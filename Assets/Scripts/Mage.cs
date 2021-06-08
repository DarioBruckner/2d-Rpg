using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MagicUser
{
    
    public Mage() : base() //This call sets standard values for a Magic User
    {
        this.s_name = "The Mage";
    }
    public bool fireball(ref CharacterClass target)
    {
        if(this.drainMP(5))
        {
            //This structure could be refactored btw. 
            double rawDamage = (this.n_magicalMight/target.n_magicalResistance) +1;
            System.Random rng = new System.Random();
            double crit = rng.Next(100) * ((this.n_agility / 100) + 1);
            if (crit > 90)
                rawDamage *= 2;
            
            int damage = (int)Math.Ceiling(rawDamage);
            target.takeMagicDamage(damage);
            return true; // Attacke Feuerball erfolgreich ausgeführt
        } 
        else
            return false; // Error: nicht genug MagieKraft
    }
    public bool thunder(ref CharacterClass target)
    {
        if (this.drainMP(8))
        {
            double rawDamage = (this.n_magicalMight / target.n_magicalResistance) + 1;
            System.Random rng = new System.Random();
            double crit = rng.Next(100) * ((this.n_agility / 100) + 1);
            if (crit > 50)
                rawDamage *= 2;

            int damage = (int)Math.Ceiling(rawDamage);
            target.takeMagicDamage(damage);
            return true; // Thunder erfolgreich ausgeführt
        }
        else
            return false; //Error: nicht genug Magiekraft
    }
}
