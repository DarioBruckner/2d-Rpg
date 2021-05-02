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
    public string Charname;

    public void resetStats()
    {
        this.HP = this.maxHP;
        this.MP = this.maxMP;
        this.strength = this.stdStrength;
        this.agility = this.stdAgility;
        this.vitality = this.stdVitality;
        this.magicalMight = this.stdMagicalMight;
        this.magicalResistance = this.stdMagicalResistance;
    }

    public CharacterClass() {
        this.lvl = 1;
        this.exp = 0;
        this.expReq = 100;
        this.maxHP = 20;
        this.maxMP = 10;
        this.stdStrength = 10;
        this.stdAgility = 10;
        this.stdVitality = 10;
        this.stdMagicalMight = 10;
        this.stdMagicalResistance = 10;
        this.resetStats();
    }
    public void levelUP()
    {
        this.maxHP = (int)Math.Ceiling((double)(this.maxHP * 1.2));
        this.maxMP = (int)Math.Ceiling((double)(this.maxMP * 1.2));
        this.stdStrength = (int)Math.Ceiling((double)(this.stdStrength * 1.2));
        this.stdAgility = (int)Math.Ceiling((double)(this.stdAgility * 1.2));
        this.stdVitality = (int)Math.Ceiling((double)(this.stdVitality * 1.2));
        this.stdMagicalMight = (int)Math.Ceiling((double)(this.stdMagicalMight * 1.2));
        this.stdMagicalResistance = (int)Math.Ceiling((double)(this.stdMagicalResistance * 1.2));
        this.resetStats();
        this.expReq += (int)Math.Ceiling((double)(this.expReq * 1.2));
        this.lvl++;
        
    }
    public void takePhysDamage(int atkStrength)
    {
        this.HP -= (atkStrength / 2);
    }
    public void takeMagicDamage(int atkMM)
    {
        this.HP -= (atkMM / 2);
    }

    public void getHealed(int heal)
    {
        if ((heal + this.HP) > this.maxHP)
        {
            this.HP = this.maxHP;
        }
        else
            this.HP += heal;

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
