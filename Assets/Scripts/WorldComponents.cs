using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldComponents : MonoBehaviour
{
    //Construct world mit Relics/Gegnern/...
    //Speichere Gegner, die gestorben sind/Quests die erfüllt sind um sie nicht zu spawnen
    //Bei Spielerkollision mit Gegner, können mithilfe von Tags/ids die Daten der Gegner gefunden werden und so bei der Transitiontobattle übertragen werden
    //Oder bei der Transition werden jeweils die Daten gespeichert und dann beim constructen der Welt so gesetzt, wie man sie vorgefunden hat. 
    public static ArrayList m_enemies = new ArrayList();
    public static ArrayList m_itemsAndArtifacts = new ArrayList();
    public static Vector3 m_playerposition;
    static bool b_firstLoad = true;
    public static bool b_ringquest = false;
    public static string s_playerobjectname="Character";

    public string s_objectID;
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

            //Copy current position n stuff as long as there are Enemies 
            if (GameObject.Find("Enemies"))
                GameObject.Find(s_playerobjectname).transform.position = m_playerposition;

            //Remove Enemies in the list from the world
            for (int j = 0; j < m_enemies.Count; j++)
                Destroy(GameObject.Find(m_enemies[j].ToString()));
            
            //Remove Items in the list from the world
            for (int j = 0; j < m_items.Count; j++)
                Destroy(GameObject.Find(m_items[j].ToString()));
        }
       
    }
}
