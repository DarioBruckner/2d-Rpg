using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform player;
    public Transform textBubble;

    // Update is called once per frame
    void Update()
    {
        float deltaX = player.position.x - transform.position.x;
        if (deltaX < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        else
            transform.localScale = new Vector3(1, 1, 1);
 
        
        if (Mathf.Abs(deltaX) < 2 && Input.GetKeyDown(KeyCode.E))
        {
            TextBubble.Create(textBubble, transform.parent.transform, new Vector3(0.5f, 2.1f, -76.3f),
                "I lost my wedding ring fighting a wolf, \nmy wife's gonna kill me! \nCan you find it for me?");
        }
    }
}
