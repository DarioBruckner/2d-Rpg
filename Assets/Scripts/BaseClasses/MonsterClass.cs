using System;

public class MonsterClass : CharacterClass
{
    public int n_expDrop;
    public MonsterClass(int level) : base() //sets Default values and level of the monster 
    {
        for(int i = 1; i < level; i++)
            this.levelUp();
    }
    public override void initialize()
    {
        base.initialize();
    }
    public virtual void initialize(int level)
    {
        base.initialize();
        for (int i = 1; i < level; i++)
            this.levelUp();
    }
    public override void attack(ref CharacterClass target)
    {
        double rawDamage = (this.n_strength / (target.n_vitality/5)) + 1;
        System.Random rng = new System.Random();
        double crit = rng.Next(100) * ((this.n_agility / 100) + 1);
        if (crit > 90)
            rawDamage *= 2;

        int damage = (int)Math.Ceiling(rawDamage);
        target.takePhysDamage(damage);
    }

}
