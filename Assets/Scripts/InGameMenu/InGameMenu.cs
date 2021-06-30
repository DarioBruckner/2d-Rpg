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
        warriorHP.text = "HP: " + WorldComponents.warrior.n_HP + "/" + WorldComponents.warrior.n_maxHP;
        warriorMP.text = "MP: " + WorldComponents.warrior.n_MP + "/" + WorldComponents.warrior.n_maxMP;

        thiefHP.text = "HP: " + WorldComponents.thief.n_HP + "/" + WorldComponents.thief.n_maxHP;
        thiefMP.text = "MP: " + WorldComponents.thief.n_MP + "/" + WorldComponents.thief.n_maxMP;

        priestHP.text = "HP: " + WorldComponents.priest.n_HP + "/" + WorldComponents.priest.n_maxHP;
        priestMP.text = "MP: " + WorldComponents.priest.n_MP + "/" + WorldComponents.priest.n_maxMP;

        mageHP.text = "HP: " + WorldComponents.mage.n_HP + "/" + WorldComponents.mage.n_maxHP;
        mageMP.text = "MP: " + WorldComponents.mage.n_MP + "/" + WorldComponents.mage.n_maxMP;
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
