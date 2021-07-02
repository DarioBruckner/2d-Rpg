using UnityEngine;

public abstract class ItemClass : MonoBehaviour
{
    public string s_itemName;
    public string s_description;
    public abstract bool action(ref CharacterClass target);

    public override bool Equals(object other)
    {
        // If parameter is null return false.
        if (other == null)
        {
            return false;
        }

        // If parameter cannot be cast to Person return false.
        ItemClass item = other as ItemClass;
        if ((System.Object)item == null)
        {
            return false;
        }

        // Return true if the fields match:
        return (item.s_itemName == this.s_itemName);
    }
}
