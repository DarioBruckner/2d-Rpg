using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform player;
    public Transform textBubble;
    private GameObject LoaderObject;
    private LevelLoader Loader;

    void Awake()
    {
        LoaderObject = GameObject.Find("LevelLoader");
        Loader = LoaderObject.GetComponent<LevelLoader>();
        
    }
    void Update()
    {
        float deltaX = player.position.x - transform.position.x;
        if (deltaX < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        else
            transform.localScale = new Vector3(1, 1, 1);
 
        
        if (Mathf.Abs(deltaX) < 2 && Input.GetKeyDown(KeyCode.E))
        {
            if(!WorldComponents.b_ringquest)
            {
                TextBubble.Create(textBubble, transform.parent.transform, new Vector3(0.5f, 2.1f, -76.3f),
                    "I lost my wedding ring fighting a wolf, \nmy wife's gonna kill me! \nCan you find it for me?");
            }
            else
            {
                //How do you create a dialogue 
                //GameObject player = GameObject.Find("Character");
                TextBubble.Create(textBubble, transform.parent.transform, new Vector3(0.5f, 2.1f, -76.3f), "You Found it! omg!\n Let's go for a beer ( ͡° ͜ʖ ͡°)");
                Destroy(GameObject.Find("WorldComponents"));
                CharacterController.b_Stop = true;
                Loader.LoadEndscreen();
                
            }
        }
    }
}
