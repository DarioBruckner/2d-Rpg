using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    public int lvl;
    public int exp;
    public int expReq;
    public int maxHP;
    public int maxMP;
    public int stdStrength;
    public int stdAgility;
    public int stdVitality;
    public int stdMagicalMight;
    public int stdMagicalResistance;
    public int HP;
    public int MP;
    public int strength;
    public int agility;
    public int vitality;
    public int magicalMight;
    public int magicalResistance;

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
    public void takePhysDamage(int atkStrength)
    {
        HP -= (atkStrength / 2);
    }
    public void takeMagicDamage(int atkMM)
    {
        HP -= (atkMM / 2);
    }

    public void getHealed(int heal)
    {
        if ((heal + HP) > maxHP)
        {
            HP = maxHP;
        }
        else
            HP += heal;

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
