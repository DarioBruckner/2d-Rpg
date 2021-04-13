using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public TextMeshProUGUI currentHealth;
    public TextMeshProUGUI maxHealth;


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        currentHealth.SetText(Convert.ToString(health));
        maxHealth.SetText(Convert.ToString(health));
        fill.color = gradient.Evaluate(1f);
    }


    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        currentHealth.SetText(Convert.ToString(health));
    }




}
