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
    public abstract bool action(ref CharacterClass user, ref CharacterClass target);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
