using UnityEngine;

public class Mage : MagicUser
{
    
    public Mage() : base() //This call sets standard values for a Magic User
    {
        this.s_name = "The Mage";
        this.abilities.Add(new Fireball());
    }
    public override void initialize()
    {
        base.initialize();
        this.s_name = "The Mage";
        this.abilities.Add(new Fireball());
    }
    public override void levelUp()
    {
        base.levelUp();
        if (this.n_lvl == 2)
        {
            abilities.Add(new Thunder());
        }
    }

}
