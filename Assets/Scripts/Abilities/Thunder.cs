using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Thunder : AbilityClass
{
    public Thunder()
    {
        this.n_lvl = 1;
        this.n_lvlReq = 2;
        this.s_name = "Thunder";
        this.s_description = "";
    }
    public override bool action(ref CharacterClass user, ref CharacterClass target)
    {
        if (user.drainMP(8))
        {
            double rawDamage = (user.n_magicalMight / target.n_magicalResistance) + 1;
            System.Random rng = new System.Random();
            double crit = rng.Next(100) * ((user.n_agility / 100) + 1);
            if (crit > 50)
                rawDamage *= 2;

            int damage = (int)Math.Ceiling(rawDamage);
            target.takeMagicDamage(damage);
            return true; // Thunder erfolgreich ausgeführt
        }
        else
            return false; //Error: nicht genug Magiekraft
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
