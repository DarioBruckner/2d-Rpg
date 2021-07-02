using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemClass : MonoBehaviour
{
    public string s_itemName;
    public string s_description;
    public abstract bool action(ref CharacterClass target);
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
