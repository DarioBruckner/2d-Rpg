using System;

public class Bat : MonsterClass
{
    public Bat(int lvlUP) : base(lvlUP)
    {
        this.s_name = "Bat";
        this.n_expDrop = 200;
        this.n_maxHP = (int)Math.Ceiling((double)(this.n_maxHP * 6));
        this.n_maxMP = (int)Math.Ceiling((double)(this.n_maxMP * 1));
        this.n_stdStrength = (int)Math.Ceiling((double)(this.n_stdStrength * 0.9));
        this.n_stdAgility = (int)Math.Ceiling((double)(this.n_stdAgility * 1.2));
        this.n_stdVitality = (int)Math.Ceiling((double)(this.n_stdVitality * 1));
        this.n_stdMagicalMight = (int)Math.Ceiling((double)(this.n_stdMagicalMight * 1));
        this.n_stdMagicalResistance = (int)Math.Ceiling((double)(this.n_stdMagicalResistance * 1));
        this.resetStats();
    }
    public override void initialize(int lvl)
    {
        base.initialize(lvl);
        this.s_name = "Bat";
        this.n_expDrop = 200;
        this.n_maxHP = (int)Math.Ceiling((double)(this.n_maxHP * 4));
        this.n_maxMP = (int)Math.Ceiling((double)(this.n_maxMP * 1));
        this.n_stdStrength = (int)Math.Ceiling((double)(this.n_stdStrength * 0.9));
        this.n_stdAgility = (int)Math.Ceiling((double)(this.n_stdAgility * 1.2));
        this.n_stdVitality = (int)Math.Ceiling((double)(this.n_stdVitality * 1));
        this.n_stdMagicalMight = (int)Math.Ceiling((double)(this.n_stdMagicalMight * 1));
        this.n_stdMagicalResistance = (int)Math.Ceiling((double)(this.n_stdMagicalResistance * 1));
        this.resetStats();
    }
}
