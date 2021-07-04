using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    public int n_lvl;
    public int n_exp;
    public int n_expReq;
    public int n_maxHP;
    public int n_maxMP;
    public int n_stdStrength;
    public int n_stdAgility;
    public int n_stdVitality;
    public int n_stdMagicalMight;
    public int n_stdMagicalResistance;
    public int n_HP;
    public int n_MP;
    public int n_strength;
    public int n_agility;
    public int n_vitality;
    public int n_magicalMight;
    public int n_magicalResistance;
    public string s_name;
    public bool b_isAlive;
    public List<AbilityClass> abilities;

    public void resetStats()
    {
        this.n_HP = this.n_maxHP;
        this.n_MP = this.n_maxMP;
        this.n_strength = this.n_stdStrength;
        this.n_agility = this.n_stdAgility;
        this.n_vitality = this.n_stdVitality;
        this.n_magicalMight = this.n_stdMagicalMight;
        this.n_magicalResistance = this.n_stdMagicalResistance;
    }

    public CharacterClass()
    {
        this.n_lvl = 1;
        this.n_exp = 0;
        this.n_expReq = 100;
        this.n_maxHP = 20;
        this.n_maxMP = 10;
        this.n_stdStrength = 10;
        this.n_stdAgility = 10;
        this.n_stdVitality = 5;
        this.n_stdMagicalMight = 10;
        this.n_stdMagicalResistance = 10;
        this.b_isAlive = true;
        this.resetStats();
        this.abilities = new List<AbilityClass>();
    }
    public virtual void initialize()
    {
        this.n_lvl = 1;
        this.n_exp = 0;
        this.n_expReq = 100;
        this.n_maxHP = 20;
        this.n_maxMP = 10;
        this.n_stdStrength = 10;
        this.n_stdAgility = 10;
        this.n_stdVitality = 5;
        this.n_stdMagicalMight = 10;
        this.n_stdMagicalResistance = 10;
        this.b_isAlive = true;
        this.resetStats();
        this.abilities = new List<AbilityClass>();
    }
    public virtual void levelUp()
    {
        this.n_maxHP = (int)Math.Ceiling((double)(this.n_maxHP * 1.2));
        this.n_maxMP = (int)Math.Ceiling((double)(this.n_maxMP * 1.2));
        this.n_stdStrength = (int)Math.Ceiling((double)(this.n_stdStrength * 1.2));
        this.n_stdAgility = (int)Math.Ceiling((double)(this.n_stdAgility * 1.2));
        this.n_stdVitality = (int)Math.Ceiling((double)(this.n_stdVitality * 1.2));
        this.n_stdMagicalMight = (int)Math.Ceiling((double)(this.n_stdMagicalMight * 1.2));
        this.n_stdMagicalResistance = (int)Math.Ceiling((double)(this.n_stdMagicalResistance * 1.2));
        this.resetStats();
        this.n_expReq += (int)Math.Ceiling((double)(this.n_expReq * 1.2));
        this.b_isAlive = true;
        this.n_lvl++;
    }

    public bool drainMP(int drain)
    {
        if (this.n_MP >= drain)
        {
            this.n_MP -= drain;
            return true;
        }
        else
            return false;
    }
    public void regenerateMP(int amount)
    {
        this.n_MP += amount;
        if (this.n_MP > this.n_maxMP)
            this.n_MP = this.n_maxMP;
    }

    public bool revive(double restore)
    {
        if(!b_isAlive) {
            b_isAlive = true;
            int heal = (int)Math.Ceiling((double)(this.n_maxHP * restore));
            this.getHealed(heal);
            return true;
        } else
        {
            return false;
        }
        
    }

    public void takePhysDamage(int atkStrength)
    {
        this.n_HP -= atkStrength;
        if (this.n_HP <= 0)
        {
            this.b_isAlive = false;
            this.n_HP = 0;
        }
    }
    public void takeMagicDamage(int atkMM)
    {
        this.n_HP -= atkMM;
        if (this.n_HP <= 0)
        {
            this.b_isAlive = false;
            this.n_HP = 0;
        }
    }

    public void getHealed(int heal)
    {
        if ((heal + this.n_HP) > this.n_maxHP)
            this.n_HP = this.n_maxHP;

        else
            this.n_HP += heal;
    }

    public virtual void attack(ref CharacterClass target)
    {
        double rawDamage = (this.n_strength / target.n_vitality) + 1;
        System.Random rng = new System.Random();
        double crit = rng.Next(100) * ((this.n_agility / 100) + 1);
        if (crit > 90)
            rawDamage *= 2;

        int damage = (int)Math.Ceiling(rawDamage);
        target.takePhysDamage(damage);
    }
    public bool gainExp(int gain)
    {
        bool leveled = false;
        if (gain > 0)
        {
            this.n_exp += gain;
        }
        while (this.n_exp >= this.n_expReq)
        {
            this.levelUp();
            leveled = true;
        }
        return leveled;
    }

}
