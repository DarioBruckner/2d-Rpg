using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : item
{
    public HealingPotion()
    {
        this.itemName = "Healing Potion";
        this.description = "Restores a little ammount of health";
    }
    public override bool action(ref CharacterClass target)
    {
        target.getHealed(10);
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
