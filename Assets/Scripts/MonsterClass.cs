using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterClass : CharacterClass
{
    public MonsterClass(int lvlUP) : base()
    {
        for(int i = 1; i < lvlUP; i++)
        {
            this.levelUP();
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
