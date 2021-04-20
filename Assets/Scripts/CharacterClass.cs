using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    protected int lvl;
    protected int exp;
    protected int expReq;
    protected int maxHP;
    protected int maxMP;
    protected int stdStrength;
    protected int stdAgility;
    protected int stdVitality;
    protected int stdMagicalMight;
    protected int stdMagicalResistance;
    protected int HP;
    protected int MP;
    protected int strength;
    protected int agility;
    protected int vitality;
    protected int magicalMight;
    protected int magicalResistance;

    public void resetStats()
    {
        HP = maxHP;
        MP = maxMP;
        strength = stdStrength;
        agility = stdAgility;
        vitality = stdVitality;
        magicalMight = stdMagicalMight;
        magicalResistance = stdMagicalResistance;
    }

    public CharacterClass() {
        lvl = 1;
        exp = 0;
        expReq = 100;
        maxHP = 20;
        maxMP = 10;
        stdStrength = 10;
        stdAgility = 10;
        stdVitality = 10;
        stdMagicalMight = 10;
        stdMagicalResistance = 10;
        resetStats();
    }
    public void levelUP()
    {
        maxHP = (int)Math.Ceiling((double)(maxHP * 1.2));
        maxMP = (int)Math.Ceiling((double)(maxMP * 1.2));
        stdStrength = (int)Math.Ceiling((double)(stdStrength * 1.2));
        stdAgility = (int)Math.Ceiling((double)(stdAgility * 1.2));
        stdVitality = (int)Math.Ceiling((double)(stdVitality * 1.2));
        stdMagicalMight = (int)Math.Ceiling((double)(stdMagicalMight * 1.2));
        stdMagicalResistance = (int)Math.Ceiling((double)(stdMagicalResistance * 1.2));
        resetStats();
        expReq += (int)Math.Ceiling((double)(expReq * 1.2));
        lvl++;
        
    }
    public void takePhysDamage()
    {

    }
    public void takeMagicDamage()
    {

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
