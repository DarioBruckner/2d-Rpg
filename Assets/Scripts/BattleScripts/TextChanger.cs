using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{

    public TextMeshProUGUI battleLog;
    public HealthBar healthBarChar1;
    public HealthBar healthBarChar2;
    public HealthBar healthBarChar3;
    public HealthBar healthBarChar4;

    public EnemyHealthBar enemyHealthbar;

    public void setLog(string Text)
    {
        battleLog.SetText(Text);
    }

    public void startupHealth(int healthchar1, int currenthealthchar1, int healthchar2, int currenthealthchar2, int healthchar3, int currenthealthchar3, int healthchar4, int currenthealthchar4, int enemyHealth, int manachar1, int currentmanachar1, int manachar2, int currentmanachar2, int manachar3, int currentmanachar3, int manachar4, int currentmanachar4)
    {
        healthBarChar1.SetMaxHealth(healthchar1);
        healthBarChar2.SetMaxHealth(healthchar2);
        healthBarChar3.SetMaxHealth(healthchar3);
        healthBarChar4.SetMaxHealth(healthchar4);

        healthBarChar1.SetHealth(currenthealthchar1);
        healthBarChar2.SetHealth(currenthealthchar2);
        healthBarChar3.SetHealth(currenthealthchar3);
        healthBarChar4.SetHealth(currenthealthchar4);

        enemyHealthbar.SetMaxHealth(enemyHealth);

        healthBarChar1.manaBar.SetMaxMana(manachar1);
        healthBarChar2.manaBar.SetMaxMana(manachar2);
        healthBarChar3.manaBar.SetMaxMana(manachar3);
        healthBarChar4.manaBar.SetMaxMana(manachar4);

        healthBarChar1.manaBar.SetMana(currentmanachar1);
        healthBarChar2.manaBar.SetMana(currentmanachar2);
        healthBarChar3.manaBar.SetMana(currentmanachar3);
        healthBarChar4.manaBar.SetMana(currentmanachar4);

    }

    public void setHealthChar(int barnum, int health)
    {
        switch (barnum)
        {
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

    public void setHealthCharByName(string name, int health)
    {
        switch (name)
        {
            case "The Mage":
                healthBarChar1.SetHealth(health);
                break;
            case "The Warrior":
                healthBarChar2.SetHealth(health);
                break;
            case "The Priest":
                healthBarChar3.SetHealth(health);
                break;
            case "The Thief":
                healthBarChar4.SetHealth(health);
                break;
        }
    }

    public void setManaByName(string name, int mana)
    {
        switch (name)
        {
            case "The Mage":
                healthBarChar1.manaBar.SetMana(mana);
                break;
            case "The Warrior":
                healthBarChar2.manaBar.SetMana(mana);
                break;
            case "The Priest":
                healthBarChar3.manaBar.SetMana(mana);
                break;
            case "The Thief":
                healthBarChar4.manaBar.SetMana(mana);
                break;
        }
    }

    public void setEnemyHealth(int health)
    {
        enemyHealthbar.SetHealth(health);
    }

}
