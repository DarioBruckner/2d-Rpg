using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direction { Left = -1, Right = 1};

public class PatrolController : MonoBehaviour
{
    public GameObject m_pointLeft;
    public GameObject m_pointRight;
    [Range(0.0f, 20f)]
    public float f_moveSpeed;
    private Direction direction = Direction.Right;
    private bool moving = true;
    private Rigidbody2D m_RigidBody;
    private Animator m_Animator;
    public Transform textBubble;

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            m_Animator.SetInteger("animNr", 1);
            if (direction == Direction.Left)
            {
                m_RigidBody.velocity = new Vector2(-f_moveSpeed, m_RigidBody.velocity.y);
                if (transform.position.x <= m_pointLeft.transform.position.x)
                {
                    direction = Direction.Right;
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            if (direction == Direction.Right)
            {
                m_RigidBody.velocity = new Vector2(f_moveSpeed, m_RigidBody.velocity.y);
                if (transform.position.x >= m_pointRight.transform.position.x)
                {
                    direction = Direction.Left;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
        } else
        {
            m_Animator.SetInteger("animNr", 0);
            m_RigidBody.velocity = new Vector2(0, m_RigidBody.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moving = false;
            if (transform.name == "Wolf")
            {
                TextBubble.Create(textBubble, transform, new Vector3(0.5f, 2.1f, -76.3f),
                "WAAAAAHRRGARRBL!");
            }
        }
    }
}
