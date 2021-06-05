using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class manaBar : MonoBehaviour{

    public Slider slider;
    public Image fill;

    public TextMeshProUGUI currentMana;
    public TextMeshProUGUI maxMana;

    public void SetMaxMana(int mana) {
        slider.maxValue = mana;
        slider.value = mana;
        currentMana.SetText(Convert.ToString(mana));
        maxMana.SetText(Convert.ToString(mana));
    }


    public void SetMana(int mana) {
        if (mana < 0) {
            mana = 0;
        }

        slider.value = mana;
        
        currentMana.SetText(Convert.ToString(mana));
    }
}
