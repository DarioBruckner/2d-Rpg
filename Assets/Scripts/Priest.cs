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
        if(target.isAlive == true)
        {
            if(this.drainMP(5))
            {
                target.getHealed((int)Math.Ceiling((double)(target.maxHP * 0.25)));
            }
            target.getHealed((int)Math.Ceiling((double)(target.maxHP * 0.25)));
        }
    }
    public void revivePlayer(ref PlayerClass target)
    {
        if(this.drainMP(10))
        {
            target.reanimate(0.1);
        }
        
    }
}
