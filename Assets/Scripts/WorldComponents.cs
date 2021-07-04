using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldComponents : MonoBehaviour
{
    //Construct world mit Relics/Gegnern/...
    //Speichere Gegner, die gestorben sind/Quests die erfüllt sind um sie nicht zu spawnen
    //Bei Spielerkollision mit Gegner, können mithilfe von Tags/ids die Daten der Gegner gefunden werden und so bei der Transitiontobattle übertragen werden
    //Oder bei der Transition werden jeweils die Daten gespeichert und dann beim constructen der Welt so gesetzt, wie man sie vorgefunden hat. 
    public GameObject m_Enemies2;
    public static ArrayList m_enemies = new ArrayList();
    public static ArrayList m_itemsAndArtifacts = new ArrayList();
    public static Vector3 m_playerposition;
    static bool b_firstLoad = true;
    public static bool b_ringquest = false;
    public static string s_playerobjectname="Character";
    
    public static string m_currentEnemy;
    public static bool b_enemyDefeated = false;
    public static Mage mage = new Mage();
    public static Priest priest = new Priest();
    public static Warrior warrior = new Warrior();
    public static Thief thief = new Thief();
    public static List<ItemClass> items = new List<ItemClass>();
    public static ArrayList m_items = new ArrayList();


    void Start()
    {
        
        
        if (b_firstLoad)
        {
            if (GameObject.Find("Character"))
                m_playerposition = GameObject.Find("Character").transform.position;
            b_firstLoad = false;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

            for (int j = 0; j < Object.FindObjectsOfType<WorldComponents>().Length; j++)
                if (Object.FindObjectsOfType<WorldComponents>()[j] != this)
                    if (Object.FindObjectsOfType<WorldComponents>()[j].name == gameObject.name)
                        Destroy(gameObject);

            

            //Remove Enemies in the list from the world
            if (!b_enemyDefeated)
            {
                if (m_enemies.Count > 0)
                {
                    m_enemies.RemoveAt(m_enemies.Count - 1);
                    m_playerposition.y += 6;
                    m_playerposition.x -= 10;
                }
            }
            else
                b_enemyDefeated = false;

            //Copy current position n stuff as long as there are Enemies 
            if (GameObject.Find("Enemies"))
                GameObject.Find(s_playerobjectname).transform.position = m_playerposition;

            for (int j = 0; j < m_enemies.Count; j++)
                Destroy(GameObject.Find(m_enemies[j].ToString()));
            
            //Remove Items in the list from the world
            for (int j = 0; j < m_items.Count; j++)
                Destroy(GameObject.Find(m_items[j].ToString()));

            if(b_ringquest)
                m_Enemies2.SetActive(true);
        }
      
    }
    public static void reset()
    {
        m_enemies = new ArrayList();
        m_itemsAndArtifacts = new ArrayList();
        b_firstLoad = true;
        b_ringquest = false;
        s_playerobjectname = "Character";
        mage = new Mage();
        priest = new Priest();
        warrior = new Warrior();
        thief = new Thief();
        items = new List<ItemClass>();
        m_items = new ArrayList();
        CharacterController.b_Stop = false;
    }

    public static void cheat(int exp)
    {
        mage.gainExp(exp);
        thief.gainExp(exp);
        warrior.gainExp(exp);
        priest.gainExp(exp);
    }

    public static void levelUp(int lvl)
    {
        Transform character = GameObject.Find("Character").GetComponent<Transform>();
    }
}
