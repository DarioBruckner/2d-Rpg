public class HealingPotion : ItemClass
{
    public HealingPotion()
    {
        this.s_itemName = "Healing Potion";
        this.s_description = "Restores a little ammount of health";
    }
    public override bool action(ref CharacterClass target)
    {
        target.getHealed(10);
        return true;
    }

}
