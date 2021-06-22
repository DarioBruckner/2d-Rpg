using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : PlayerClass
{

   
    public Thief() : base()
    {
        this.s_name = "The Thief";
        this.n_maxHP = (int)Math.Ceiling((double)(this.n_maxHP * 1));
        this.n_maxMP = (int)Math.Ceiling((double)(this.n_maxMP * 0.6));
        this.n_stdStrength = (int)Math.Ceiling((double)(this.n_stdStrength * 1.2));
        this.n_stdAgility = (int)Math.Ceiling((double)(this.n_stdAgility * 1.5));
        this.n_stdVitality = (int)Math.Ceiling((double)(this.n_stdVitality * 1));
        this.n_stdMagicalMight = (int)Math.Ceiling((double)(this.n_stdMagicalMight * 0));
        this.n_stdMagicalResistance = (int)Math.Ceiling((double)(this.n_stdMagicalResistance * 1));
        this.resetStats();
    }
    public override void initialize()
    {
        base.initialize();
        this.s_name = "The Thief";
        this.n_maxHP = (int)Math.Ceiling((double)(this.n_maxHP * 1));
        this.n_maxMP = (int)Math.Ceiling((double)(this.n_maxMP * 0.6));
        this.n_stdStrength = (int)Math.Ceiling((double)(this.n_stdStrength * 1.2));
        this.n_stdAgility = (int)Math.Ceiling((double)(this.n_stdAgility * 1.5));
        this.n_stdVitality = (int)Math.Ceiling((double)(this.n_stdVitality * 1));
        this.n_stdMagicalMight = (int)Math.Ceiling((double)(this.n_stdMagicalMight * 0));
        this.n_stdMagicalResistance = (int)Math.Ceiling((double)(this.n_stdMagicalResistance * 1));
        this.resetStats();
    }
    public override void levelUp()
    {
        base.levelUp();
        if (this.n_lvl == 2)
        {
            abilities.Add(new MultiSlash());
        }
    }

}
