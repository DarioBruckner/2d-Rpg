using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonsterClass
{
    //It is really important that this stuff is NOT public. it can be modified in the editor, and will be if there are some values in there
    //The editor seems to modify the values as the last member in the chain and therefore whatever stands in the editor, is the last value!
    //Thats probably why there is SerializeFields with the private option. but not really sure about that.
    //Most likely, the current solution might introduce not intended bugs or hard to find ones.
    //And with further enemies, it might not be scaleable (2v4 f.e. as this is one item on our board.
    //The membervariables need to be private and the values should be set in the code
    //not in the editor... We should defo discuss this.
    public Wolf(int lvlUP) : base(lvlUP)
    {
        this.s_name = "Wolf";
        this.n_maxHP = (int)Math.Ceiling((double)(n_maxHP * 2));
        this.n_stdStrength = (int)Math.Ceiling((double)(n_stdStrength * 0.5));
        this.resetStats();
    }




    // Start is called before the first frame update
    void Start()
    {
        this.n_maxHP = 200;
        this.n_HP = 200;
        this.s_name = "Wolf";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}