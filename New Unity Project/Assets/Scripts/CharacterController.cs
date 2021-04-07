using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float moveSpeed = 0.1f;
    Rigidbody2D m_Rigidbody;
    public float m_Thrust = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            m_Rigidbody.AddForce(transform.up * m_Thrust);
        }

    }
}
