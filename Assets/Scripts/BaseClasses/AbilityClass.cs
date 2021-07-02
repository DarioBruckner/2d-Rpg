public abstract class AbilityClass
{
    public string s_name;
    public string s_description;
    public int n_lvl;
    public int n_lvlReq;
    public int n_uses;
    public bool b_targetEnemy;
    public abstract bool enemyAction(ref CharacterClass user, ref MonsterClass target);
    public abstract bool allyAction(ref CharacterClass user, ref PlayerClass target);
    public void levelUp()
    {
        if(this.n_lvl < 5)
            this.n_lvl++;
    }

    public string getName() {
        return this.s_name;
    }
}
