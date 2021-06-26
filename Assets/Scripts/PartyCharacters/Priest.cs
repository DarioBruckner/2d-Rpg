using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : MagicUser
{
    public Priest() : base() //Set default values from MagicUser + implement Name
    {
        this.s_name = "The Priest";
        abilities.Add(new Heal());
    }
    public override void initialize()
    {
        base.initialize();
        this.s_name = "The Priest";
        abilities.Add(new Heal());
    }
    public override void levelUp()
    {
        base.levelUp();
        if(this.n_lvl == 2)
        {
            abilities.Add(new Revive());
        }
    }
}
