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
        this.n_uses = 0; //Check after combat if this is a multiple of 5
        this.b_targetEnemy = true;
    }
    public override bool enemyAction(ref CharacterClass user, ref MonsterClass target)
    {
        if (user.drainMP(8))
        {
            double rawDamage = (user.n_magicalMight / target.n_magicalResistance) + 1;
            System.Random rng = new System.Random();
            double crit = rng.Next(100) * ((user.n_agility / 100) + 1);
            if (crit > 50)
                rawDamage *= 2;

            int damage = (int)Math.Ceiling(rawDamage + ((this.n_lvl * 0.1) + 0.9));
            target.takeMagicDamage(damage);
            this.n_uses++;
            if (this.n_uses % 5 == 0)
            {
                this.levelUp();
            }
            return true; // Thunder erfolgreich ausgeführt
        }
        else
            return false; //Error: nicht genug Magiekraft
    }
    public override bool allyAction(ref CharacterClass user, ref PlayerClass target)
    {
        return false;
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
