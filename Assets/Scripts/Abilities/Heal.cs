using System;

public class Heal : AbilityClass
{
    
    public Heal()
    {
        this.n_lvl = 1;
        this.n_lvlReq = 1;
        this.s_name = "Heal";
        this.s_description = "";
        this.n_uses = 0; //Check after combat if this is a multiple of 5
        this.b_targetEnemy = false;
    }
    public override bool allyAction(ref CharacterClass user, ref PlayerClass target)
    {
        if (target.b_isAlive == true)
        {
            if (user.drainMP(5))
            {
                int value = (int)Math.Ceiling((double)(target.n_maxHP * 0.25 + ((this.n_lvl * 0.1) - 0.1)));
                Console.WriteLine(value);
                
                target.getHealed(value);
                
                this.n_uses++;
                if (this.n_uses % 5 == 0)
                {
                    this.levelUp();
                }
                return true;
            } else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public override bool enemyAction(ref CharacterClass user, ref MonsterClass target) {
        return false;
    }
}
