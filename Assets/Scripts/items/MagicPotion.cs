using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPotion : ItemClass
{
    public MagicPotion()
    {
        this.s_itemName = "Magic Potion";
        this.s_description = "Restores a little ammount of Magicpoints";
    }
    public override bool action(ref CharacterClass target)
    {
        target.regenerateMP(10);
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
