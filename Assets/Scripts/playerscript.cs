using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerscript : MonoBehaviour
{

    public int maxHealth = 100;
    public int maxHealthEnemy = 2000;
    public int currentHealth;
    public int currentHealthEnemy;

    public HealthBar healthBarChar1;
    public HealthBar healthBarChar2;
    public HealthBar healthBarChar3;
    public HealthBar healthBarChar4;

    public EnemyHealthBar healthbarEnemy;

 


    //public HealthBar healthBarChar4;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentHealthEnemy = maxHealthEnemy;
        healthBarChar1.SetMaxHealth(maxHealth);
        healthBarChar2.SetMaxHealth(maxHealth);
        healthBarChar3.SetMaxHealth(maxHealth);
        healthBarChar4.SetMaxHealth(maxHealth);

        healthbarEnemy.SetMaxHealth(maxHealthEnemy);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;

        healthBarChar1.SetHealth(currentHealth);
        healthBarChar2.SetHealth(currentHealth -10);
        healthBarChar3.SetHealth(currentHealth -20);
        healthBarChar4.SetHealth(currentHealth -30);
    }

    public void enemyTakeDamage(int damage)
    {
        currentHealthEnemy -= damage;
        healthbarEnemy.SetHealth(currentHealthEnemy);
    }
}
