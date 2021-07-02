using System;


public class MultiSlash : AbilityClass
{
    public MultiSlash()
    {
        this.n_lvl = 1;
        this.n_lvlReq = 2;
        this.s_name = "Multi Slash";
        this.s_description = "";
        this.n_uses = 0; //Check after combat if this is a multiple of 5
        this.b_targetEnemy = true;
    }
    public override bool enemyAction(ref CharacterClass user, ref MonsterClass target)
    {
        if (user.drainMP(3))
        {
            //generates random amount of Attacks between 1 and 6
            System.Random rng = new System.Random();
            int attacks = rng.Next(1, 6);
            for (int i = 0; i < attacks; i++)
            {
                double rawDamage = ((user.n_strength * 0.75) / target.n_vitality) + 1;
                double crit = rng.Next(100) * ((user.n_agility / 100) + 1);
                if (crit > 80)
                    rawDamage *= 2;

                int damage = (int)Math.Ceiling(rawDamage + ((this.n_lvl * 0.1) + 0.9));
                target.takePhysDamage(damage);
            }
            this.n_uses++;
            if (this.n_uses % 5 == 0)
            {
                this.levelUp();
            }
            return true; //Attack was successful
        }
        else
            return false; //Error: Not enough Magic Power
    }
    public override bool allyAction(ref CharacterClass user, ref PlayerClass target)
    {
        return false;
    }
}
