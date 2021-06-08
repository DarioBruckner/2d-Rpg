using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : MagicUser
{
    public Priest() : base() //Set default values from MagicUser + implement Name
    {
        this.s_name = "The Priest";
    }

    public void heal(ref CharacterClass target) //Changed from PlayerClass -> CharacterClass
    {
        if(target.b_isAlive == true)
        {
            if(this.drainMP(5))
                target.getHealed((int)Math.Ceiling((double)(target.n_maxHP * 0.25)));

            target.getHealed((int)Math.Ceiling((double)(target.n_maxHP * 0.25))); //You get healed twice?
        }
    }
    public void reviveCharacter(ref CharacterClass target) //same here
    {
        if(this.drainMP(10))
            target.revive(0.1);
        
    }
}
