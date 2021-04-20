using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextChanger : MonoBehaviour {


    public TextMeshProUGUI battleLog;

    public HealthBar healthBarChar1;
    public HealthBar healthBarChar2;
    public HealthBar healthBarChar3;
    public HealthBar healthBarChar4;


    public EnemyHealthBar enemyHealthbar;



    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void setLog(string Text) {
        battleLog.SetText(Text);
    }



    public void startupHealth(int healthchar1, int healthchar2, int healthchar3, int healthchar4, int enemyHealth) {
        healthBarChar1.SetMaxHealth(healthchar1);
        healthBarChar2.SetMaxHealth(healthchar2);
        healthBarChar3.SetMaxHealth(healthchar3);
        healthBarChar4.SetMaxHealth(healthchar4);

        enemyHealthbar.SetMaxHealth(enemyHealth);
    }

    public void setHealthChar(int barnum, int health) {
        switch (barnum) {
            case 1:
                healthBarChar1.SetHealth(health);
                break;
            case 2:
                healthBarChar2.SetHealth(health);
                break;
            case 3:
                healthBarChar3.SetHealth(health);
                break;
            case 4:
                healthBarChar4.SetHealth(health);
                break;
        }
    }
    public void setEnemyHealth(int health) {
        enemyHealthbar.SetHealth(health);
    }

}
