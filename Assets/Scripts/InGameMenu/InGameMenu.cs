using System;
using TMPro;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public static bool b_isPaused = false;
    public GameObject m_inGameMenu;
    public GameObject m_partyMenu;
    public GameObject m_itemMenu;
    public TextMeshProUGUI warriorHP;
    public TextMeshProUGUI warriorMP;
    public TextMeshProUGUI thiefHP;
    public TextMeshProUGUI thiefMP;
    public TextMeshProUGUI priestHP;
    public TextMeshProUGUI priestMP;
    public TextMeshProUGUI mageHP;
    public TextMeshProUGUI mageMP;
    public TextMeshProUGUI warriorLVL;
    public TextMeshProUGUI warriorEXP;
    public TextMeshProUGUI thiefLVL;
    public TextMeshProUGUI thiefEXP;
    public TextMeshProUGUI priestLVL;
    public TextMeshProUGUI priestEXP;
    public TextMeshProUGUI mageLVL;
    public TextMeshProUGUI mageEXP;
    public TextMeshProUGUI m_healthPotionButton;
    public TextMeshProUGUI m_magicPotionButton;
    public TextMeshProUGUI m_itemReceiveText;
    private string s_itemInUse = "";

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
        warriorLVL.text = "LVL: " + WorldComponents.warrior.n_lvl;
        warriorEXP.text = "EXP: " + WorldComponents.warrior.n_exp + "/" + WorldComponents.warrior.n_expReq;

        thiefHP.text = "HP: " + WorldComponents.thief.n_HP + "/" + WorldComponents.thief.n_maxHP;
        thiefMP.text = "MP: " + WorldComponents.thief.n_MP + "/" + WorldComponents.thief.n_maxMP;
        thiefLVL.text = "LVL: " + WorldComponents.thief.n_lvl;
        thiefEXP.text = "EXP: " + WorldComponents.thief.n_exp + "/" + WorldComponents.warrior.n_expReq;

        priestHP.text = "HP: " + WorldComponents.priest.n_HP + "/" + WorldComponents.priest.n_maxHP;
        priestMP.text = "MP: " + WorldComponents.priest.n_MP + "/" + WorldComponents.priest.n_maxMP;
        priestLVL.text = "LVL: " + WorldComponents.priest.n_lvl;
        priestEXP.text = "EXP: " + WorldComponents.priest.n_exp + "/" + WorldComponents.warrior.n_expReq;

        mageHP.text = "HP: " + WorldComponents.mage.n_HP + "/" + WorldComponents.mage.n_maxHP;
        mageMP.text = "MP: " + WorldComponents.mage.n_MP + "/" + WorldComponents.mage.n_maxMP;
        mageLVL.text = "LVL: " + WorldComponents.mage.n_lvl;
        mageEXP.text = "EXP: " + WorldComponents.mage.n_exp + "/" + WorldComponents.warrior.n_expReq;
    }

    public void UnloadPartyMenu()
    {
        m_partyMenu.SetActive(false);
        m_itemReceiveText.text = "";
        s_itemInUse = "";
    }
    public void LoadItemMenu()
    {
        m_itemMenu.SetActive(true);
        UnloadPartyMenu();
        int healthCount = 0;
        int magicCount = 0;
        foreach (ItemClass item in WorldComponents.items)
        {
            if (item.s_itemName == "Healing Potion")
            {
                healthCount++;
            } else if (item.s_itemName == "Magic Potion")
            {
                magicCount++;
            }
        }
        m_healthPotionButton.text = "Health Potion x" + healthCount / 2;
        m_magicPotionButton.text = "Magic Potion x" + magicCount / 2;
    }

    public void UnloadItemMenu()
    {
        m_itemMenu.SetActive(false);
    }

    public void useItem(string item)
    {
        s_itemInUse = item;
        if (item == "healthPotion" && WorldComponents.items.Contains(new HealingPotion()))
        {
            m_itemReceiveText.text = "Who will receive the Health Potion?";
        } else if (item == "magicPotion" && WorldComponents.items.Contains(new MagicPotion()))
        {
            m_itemReceiveText.text = "Who will receive the Magic Potion?";
        }
        if (m_itemReceiveText.text != "")
        {
            UnloadItemMenu();
            LoadPartyMenu();
        }
    }

    public void giveItemTo(string character)
    {
        if (s_itemInUse == "")
        {
            return;
        }
        ItemClass item;
        if (s_itemInUse == "healthPotion")
        {
            item = new HealingPotion();
        } else
        {
            item = new MagicPotion();
        }
        CharacterClass giveTo = new Warrior();
        switch (character)
        {
            case "warrior":
                giveTo = WorldComponents.warrior;
                break;
            case "thief":
                giveTo = WorldComponents.thief;
                break;
            case "mage":
                giveTo = WorldComponents.mage;
                break;
            case "priest":
                giveTo = WorldComponents.priest;
                break;
        }
        item.action(ref giveTo);
        WorldComponents.items.Remove(item);
        WorldComponents.items.Remove(item);
        UnloadPartyMenu();
        LoadItemMenu();
    }
}
