using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : magicUser
{

    
    public Priest() : base()
    {
        this.Charname = "The Priest";
    }

    public void heal(ref PlayerClass target)
    {
        target.getHealed((int)Math.Ceiling((double)(target.maxHP * 0.25)));
        MP -= 5;
    }
}
