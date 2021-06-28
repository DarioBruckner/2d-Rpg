using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Fireball : AbilityClass
{
    public Fireball()
    {
        this.n_lvl = 1;
        this.n_lvlReq = 1;
        this.s_name = "Fireball";
        this.s_description = "";
        this.n_uses = 0; //Check after combat if this is a multiple of 5
    }
    public override bool action(ref CharacterClass user, ref CharacterClass target)
    {
        if (user.drainMP(5))
        {
            //This structure could be refactored btw. 
            double rawDamage = (user.n_magicalMight / target.n_magicalResistance) + 1;
            System.Random rng = new System.Random();
            double crit = rng.Next(100) * ((user.n_agility / 100) + 1);
            if (crit > 90)
                rawDamage *= 2;

            int damage = (int)Math.Ceiling(rawDamage + ((this.n_lvl * 0.1) + 0.9));
            target.takeMagicDamage(damage);
            this.n_uses++;
            if(this.n_uses%5 == 0)
            {
                this.levelUp();
            }
            return true; // Attacke Feuerball erfolgreich ausgeführt
        }
        else
            return false; // Error: nicht genug MagieKraft
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
