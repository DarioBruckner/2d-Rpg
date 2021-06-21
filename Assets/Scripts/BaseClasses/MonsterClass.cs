public class MonsterClass : CharacterClass
{
    public MonsterClass(int level) : base() //sets Default values and level of the monster 
    {
        for(int i = 1; i < level; i++)
            this.levelUp();
    }
    

}
