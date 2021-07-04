using System;

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
        this.n_expDrop = 100;
        this.n_maxHP = (int)Math.Ceiling((double)(this.n_maxHP * 6));
        this.n_maxMP = (int)Math.Ceiling((double)(this.n_maxMP * 1));
        this.n_stdStrength = (int)Math.Ceiling((double)(this.n_stdStrength * 1.2));
        this.n_stdAgility = (int)Math.Ceiling((double)(this.n_stdAgility * 0.9));
        this.n_stdVitality = (int)Math.Ceiling((double)(this.n_stdVitality * 1.2));
        this.n_stdMagicalMight = (int)Math.Ceiling((double)(this.n_stdMagicalMight * 1));
        this.n_stdMagicalResistance = (int)Math.Ceiling((double)(this.n_stdMagicalResistance * 0.9));
        this.resetStats();
    }

    public override void initialize(int lvl)
    {
        base.initialize(lvl);
        this.n_expDrop = 100;
        this.s_name = "Wolf";
        this.n_maxHP = (int)Math.Ceiling((double)(this.n_maxHP * 6));
        this.n_maxMP = (int)Math.Ceiling((double)(this.n_maxMP * 1));
        this.n_stdStrength = (int)Math.Ceiling((double)(this.n_stdStrength * 1.2));
        this.n_stdAgility = (int)Math.Ceiling((double)(this.n_stdAgility * 0.9));
        this.n_stdVitality = (int)Math.Ceiling((double)(this.n_stdVitality * 1.2));
        this.n_stdMagicalMight = (int)Math.Ceiling((double)(this.n_stdMagicalMight * 1));
        this.n_stdMagicalResistance = (int)Math.Ceiling((double)(this.n_stdMagicalResistance * 0.9));
        this.resetStats();
    }
}
