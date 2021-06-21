using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public static bool b_isPaused = false;
    public GameObject m_inGameMenu;
    public GameObject m_partyMenu;

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
    }

    public void LoadPartyMenu()
    {
        m_partyMenu.SetActive(true);
    }
}
