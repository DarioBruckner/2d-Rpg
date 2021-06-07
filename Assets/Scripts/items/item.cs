using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class item : MonoBehaviour
{
    public string itemName;
    public string description;
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
