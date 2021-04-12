using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBarChar1;
    public HealthBar healthBarChar2;
    public HealthBar healthBarChar3;
    //public HealthBar healthBarChar4;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarChar1.SetMaxHealth(maxHealth);
        healthBarChar2.SetMaxHealth(maxHealth);
        healthBarChar3.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage){
        currentHealth -= damage;

        healthBarChar1.SetHealth(currentHealth);
        healthBarChar2.SetHealth(currentHealth -10);
        healthBarChar3.SetHealth(currentHealth -20);
        //healthBarChar4.SetHealth(currentHealth + 30);
    }
}
