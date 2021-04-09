using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Range(5.0f, 15.0f)]
    public float f_MoveSpeed;
    Rigidbody2D m_Rigidbody;
    [Range(5.0f, 15.0f)]
    public float m_Thrust;
    CapsuleCollider2D m_BodyCollider;
    public LayerMask layerMask;
    float f_LastAxis = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        CapsuleCollider2D[] m_BodyColliders = GetComponents<CapsuleCollider2D>();
        foreach (CapsuleCollider2D col in m_BodyColliders)
        {
            if (col.sharedMaterial.name == "CharacterBody")
            {
                m_BodyCollider = col;
            }
        }
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
        m_Rigidbody.velocity = new Vector2(f_MoveSpeed * Input.GetAxis("Horizontal"), m_Rigidbody.velocity.y);
        if (Mathf.Sign(Input.GetAxis("Horizontal")) != Mathf.Sign(f_LastAxis) && IsGrounded())
        {
            m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, -1);
        }
        f_LastAxis = Input.GetAxis("Horizontal");
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + new Vector3(0, -m_BodyCollider.size.y/2 + 0.1f, 0), 
                                new Vector2(m_BodyCollider.size.x - 0.1f, 0.1f), 0, Vector2.down, 0.2f, layerMask);
        return hit.collider != null;
    }
}
