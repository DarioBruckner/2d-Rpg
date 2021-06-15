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
}
