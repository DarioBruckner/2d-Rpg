using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class LevelLoader : MonoBehaviour
{
    public object enemy;
    public Animator transition;
    private float transitionTime = 1f;
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

    public void LoadBattle(object other) 
    { 
        enemy = other; //Other is the object the player collided with which is stored in enemy. Can be used to construct the fight_scene
        StartCoroutine(Loader("fight_scene"));
    }

    public void LoadWorld()
    {
        StartCoroutine(Loader("level_0"));
    }
    IEnumerator Loader(string scene)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        { 
            LoadBattle("lol");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
