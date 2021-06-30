using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class LevelLoader : MonoBehaviour
{
    public GameObject enemy;
    public Animator transition;
    private float transitionTime = 1f;
    private bool b_loaded = true;
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.B)) //Bei collision mit einem Player, könnte man hier die Daten speichern des Objektes.
        //{
        //    LoadBattle("lol");
        //}
        if (Input.GetKeyDown(KeyCode.W)) //Wenn zb Der Gegner besiegt is, trigger Load World. World braucht dann eine Klasse, die das Objekt von einem Array entfernt oder so.
        {
            LoadWorld();
        }
    }

    public void LoadBattle(GameObject other) 
    {
        if(b_loaded)
        {
            WorldComponents.m_playerposition = other.transform.position;
            WorldComponents.m_enemies.Add(this.transform.parent.name);
            b_loaded = false;
        }
        
        //WorldComponents.Destroy(this);
        /*
        foreach(Transform child in WorldComponents.m_enemies.transform.get
        {
            if (this.transform.name == child.name)
                child.parent = null;
        }*/
        //enemy = other; //Other is the object the player collided with which is stored in enemy. Can be used to construct the fight_scene
        StartCoroutine(Loader("fight_scene"));
    }

    public void LoadWorld()
    {
        StartCoroutine(Loader("level_0"));
    }
    public void LoadMainMenu()
    {
        StartCoroutine(Loader("main menu"));
        Time.timeScale = 1f;
    }
    IEnumerator Loader(string scene)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }
    IEnumerator Loader_end(string scene)
    {
        yield return new WaitForSeconds(2f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        { 
            LoadBattle(other.gameObject);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadEndscreen()
    {

        StartCoroutine(Loader_end("credits"));
    }
}
