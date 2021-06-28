using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class AbilityClass
{
    public string s_name;
    public string s_description;
    public int n_lvl;
    public int n_lvlReq;
    public int n_uses;
    public bool b_targetEnemy;
    public abstract bool enemyAction(ref CharacterClass user, ref MonsterClass target);
    public abstract bool allyAction(ref CharacterClass user, ref PlayerClass target);
    public void levelUp()
    {
        if(this.n_lvl < 5)
            this.n_lvl++;
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
