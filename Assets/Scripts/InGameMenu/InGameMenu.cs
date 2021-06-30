using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public static bool b_isPaused = false;
    public GameObject m_inGameMenu;
    public GameObject m_partyMenu;
    public GameObject m_itemMenu;
    public GameObject m_worldComponents;
    public TextMeshProUGUI warriorHP;
    public TextMeshProUGUI warriorMP;
    public TextMeshProUGUI thiefHP;
    public TextMeshProUGUI thiefMP;
    public TextMeshProUGUI priestHP;
    public TextMeshProUGUI priestMP;
    public TextMeshProUGUI mageHP;
    public TextMeshProUGUI mageMP;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (b_isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        b_isPaused = true;
        Time.timeScale = 0f;
        m_inGameMenu.SetActive(true);
    }

    private void Resume()
    {
        b_isPaused = false;
        Time.timeScale = 1f;
        m_inGameMenu.SetActive(false);
        UnloadPartyMenu();
        UnloadItemMenu();
    }

    public void LoadPartyMenu()
    {
        m_partyMenu.SetActive(true);
        UnloadItemMenu();
        float maxHP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Warrior").n_maxHP;
        float maxMP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Warrior").n_maxMP;
        float HP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Warrior").n_HP;
        float MP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Warrior").n_MP;
        warriorHP.text = "HP: " + HP + "/" + maxHP;
        warriorMP.text = "MP: " + MP + "/" + maxMP;

        maxHP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Thief").n_maxHP;
        maxMP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Thief").n_maxMP;
        HP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Thief").n_HP;
        MP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Thief").n_MP;
        thiefHP.text = "HP: " + HP + "/" + maxHP;
        thiefMP.text = "MP: " + MP + "/" + maxMP;

        maxHP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Priest").n_maxHP;
        maxMP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Priest").n_maxMP;
        HP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Priest").n_HP;
        MP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Priest").n_MP;
        priestHP.text = "HP: " + HP + "/" + maxHP;
        priestMP.text = "MP: " + MP + "/" + maxMP;

        maxHP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Mage").n_maxHP;
        maxMP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Mage").n_maxMP;
        HP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Mage").n_HP;
        MP = m_worldComponents.GetComponent<WorldComponents>().GetCharacter("The Mage").n_MP;
        mageHP.text = "HP: " + HP + "/" + maxHP;
        mageMP.text = "MP: " + MP + "/" + maxMP;
    }

    public void UnloadPartyMenu()
    {
        m_partyMenu.SetActive(false);
    }
    public void LoadItemMenu()
    {
        m_itemMenu.SetActive(true);
        UnloadPartyMenu();
    }

    public void UnloadItemMenu()
    {
        m_itemMenu.SetActive(false);
    }
}
