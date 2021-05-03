using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonsterClass
{



    public Wolf(int lvlUP) : base(lvlUP)
    {
        this.Charname = "Wolf";
        this.maxHP = (int)Math.Ceiling((double)(maxHP * 2));
        this.stdStrength = (int)Math.Ceiling((double)(stdStrength * 0.5));
        this.resetStats();
    }




    // Start is called before the first frame update
    void Start()
    {
        this.maxHP = 200;
        this.HP = 200;
        this.Charname = "Wolf";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
