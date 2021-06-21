using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MagicUser
{
    
    public Mage() : base() //This call sets standard values for a Magic User
    {
        this.s_name = "The Mage";
        this.abilities.Add(new Fireball());
    }
    public override void levelUp()
    {
        base.levelUp();
        if (this.n_lvl == 2)
        {
            abilities.Add(new Thunder());
        }
    }

}
