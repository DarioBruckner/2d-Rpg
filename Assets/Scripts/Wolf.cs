using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonsterClass
{
    public Wolf(int lvlUP) : base(lvlUP)
    {
        maxHP = (int)Math.Ceiling((double)(maxHP * 2));
        stdStrength = (int)Math.Ceiling((double)(stdStrength * 0.5));
        resetStats();
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
