using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveCamera : MonoBehaviour
{
    public GameObject TargetPosition;
    public float speed = 0.1f;
    public GameObject Background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Background.transform.position = Vector3.Lerp(Background.transform.position, TargetPosition.transform.position, speed * Time.deltaTime);

    }
}
