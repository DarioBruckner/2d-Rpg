using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Heal : AbilityClass
{
    public Heal()
    {
        this.n_lvl = 1;
        this.n_lvlReq = 1;
        this.s_name = "Heal";
        this.s_description = "";
    }
    public override bool action(ref CharacterClass user, ref CharacterClass target)
    {
        if (target.b_isAlive == true)
        {
            if (user.drainMP(5))
            {
                target.getHealed((int)Math.Ceiling((double)(target.n_maxHP * 0.25)));
                return true;
            } else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
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
