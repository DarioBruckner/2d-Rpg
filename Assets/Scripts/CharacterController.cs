using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Range(5.0f, 15.0f)]
    public float moveSpeed;
    Rigidbody2D m_Rigidbody;
    [Range(5.0f, 15.0f)]
    public float m_Thrust;
    CapsuleCollider2D capsuleCollider;
    public LayerMask layerMask;
    float runFactor = 0.0f;
    bool running = false;
    [Range(0.0f, 0.99f)]
    public float dampening; //I've Added A comment möp - Dario pls no kick ty - Aleks

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            m_Rigidbody.AddForce(transform.up * m_Thrust, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        /*
        running = false;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            running = true;
            m_Rigidbody.velocity = new Vector2( - moveSpeed * runFactor, m_Rigidbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            running = true;
            m_Rigidbody.velocity = new Vector2(moveSpeed * runFactor, m_Rigidbody.velocity.y);
        }
        if (running)
        {
            runFactor += 1.0f - dampening;
            runFactor = runFactor >= 1.0f ? 1.0f : runFactor;
        } else
        {
            runFactor = 0.0f;
        }
        */
        m_Rigidbody.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), m_Rigidbody.velocity.y);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + new Vector3(0, -capsuleCollider.size.y/2, 0), 
                                new Vector2(capsuleCollider.size.x - 0.1f, 0.1f), 0, Vector2.down, 0.1f, layerMask);
        return hit.collider != null;
    }
}
