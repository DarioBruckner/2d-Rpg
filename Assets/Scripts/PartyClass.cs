using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyClass : MonoBehaviour
{
    public Mage mage;
    public Priest priest;
    public Thief thief;
    public Warrior warrior;
    public List<ItemClass> items;

    public PartyClass()
    {
        this.mage = new Mage();
        this.priest = new Priest();
        this.thief = new Thief();
        this.warrior = new Warrior();
        this.items = new List<ItemClass>();
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
