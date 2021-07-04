using System;

public class Drake : MonsterClass
{
    public Drake(int lvlUP) : base(lvlUP)
    {
        this.s_name = "Drake";
        this.n_expDrop = 300;
        this.n_maxHP = (int)Math.Ceiling((double)(this.n_maxHP * 4));
        this.n_maxMP = (int)Math.Ceiling((double)(this.n_maxMP * 1));
        this.n_stdStrength = (int)Math.Ceiling((double)(this.n_stdStrength * 1));
        this.n_stdAgility = (int)Math.Ceiling((double)(this.n_stdAgility * 1));
        this.n_stdVitality = (int)Math.Ceiling((double)(this.n_stdVitality * 5));
        this.n_stdMagicalMight = (int)Math.Ceiling((double)(this.n_stdMagicalMight * 1.5));
        this.n_stdMagicalResistance = (int)Math.Ceiling((double)(this.n_stdMagicalResistance * 0.5));
        this.resetStats();
    }
    public override void initialize(int lvl)
    {
        base.initialize(lvl);
        this.s_name = "Drake";
        this.n_expDrop = 300;
        this.n_maxHP = (int)Math.Ceiling((double)(this.n_maxHP * 4));
        this.n_maxMP = (int)Math.Ceiling((double)(this.n_maxMP * 1));
        this.n_stdStrength = (int)Math.Ceiling((double)(this.n_stdStrength * 1));
        this.n_stdAgility = (int)Math.Ceiling((double)(this.n_stdAgility * 1));
        this.n_stdVitality = (int)Math.Ceiling((double)(this.n_stdVitality * 5));
        this.n_stdMagicalMight = (int)Math.Ceiling((double)(this.n_stdMagicalMight * 1.5));
        this.n_stdMagicalResistance = (int)Math.Ceiling((double)(this.n_stdMagicalResistance * 0.5));
        this.resetStats();
    }
    public override void attack(ref CharacterClass target)
    {
        double rawDamage = (this.n_magicalMight / ((target.n_magicalResistance/5))) + 1;
        System.Random rng = new System.Random();
        double crit = rng.Next(100) * ((this.n_agility / 100) + 1);
        if (crit > 90)
            rawDamage *= 2;

        int damage = (int)Math.Ceiling(rawDamage);
        target.takeMagicDamage(damage);
    }
}
