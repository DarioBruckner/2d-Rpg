using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour //Name CharacterControlleris already taken by UnityEngine -> MyCharacterController? + Reconnecting with other assets in editor
{
    
    [Range(5.0f, 15.0f)] 
    public float f_MoveSpeed;
    [Range(5.0f, 15.0f)]
    public float m_Thrust;
    [Range(5f, 20f)]
    public float f_MaxJumpImpulse;
    public LayerMask layerMask;
    Rigidbody2D m_Rigidbody;
    CapsuleCollider2D m_BodyCollider;
    public Transform textBubblePrefab; 
    public AudioSource JumpSound;
    private Animator m_Animator;
    private float f_LastAxis = 0.0f;
    private bool b_Jump = false;
    private float f_JumpTime = 0.0f;
    public static bool b_Stop = false;


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        CapsuleCollider2D[] m_BodyColliders = GetComponents<CapsuleCollider2D>();
        
        foreach (CapsuleCollider2D col in m_BodyColliders)
            if (col.sharedMaterial.name == "CharacterBody")
                m_BodyCollider = col;
    }

    // Update is called once per frame
    void Update()
    {
        if (!b_Jump)
        {
            if (!b_Stop)
            {
                if (Input.GetAxis("Horizontal") != 0 && IsGrounded())
                    m_Animator.SetInteger("animNr", 1);
                
                else if (IsGrounded())
                    m_Animator.SetInteger("animNr", 0);
                
                if (Input.GetAxis("Horizontal") < 0)
                    transform.localScale = new Vector3(-1, 1, 1);
                
                else if (Input.GetAxis("Horizontal") > 0)
                    transform.localScale = new Vector3(1, 1, 1);
                
                if (m_Rigidbody.velocity.y < 0 && !IsGrounded())
                    m_Animator.SetInteger("animNr", 3);
                
                if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                {
                    JumpSound.Play();
                    m_Animator.SetInteger("animNr", 2);
                    m_Rigidbody.AddForce(transform.up * m_Thrust, ForceMode2D.Impulse);
                    b_Jump = true;
                }
            }
        }
        else
        {
            f_JumpTime += Time.deltaTime;
            if (f_JumpTime >= 0.2f)
            {
                f_JumpTime = 0.0f;
                b_Jump = false;
            }
        }
        if (m_Rigidbody.velocity.y > f_MaxJumpImpulse)
            m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, f_MaxJumpImpulse);
    }

    private void FixedUpdate()
    {
        if (!b_Stop)
            m_Rigidbody.velocity = new Vector2(f_MoveSpeed * Input.GetAxis("Horizontal"), m_Rigidbody.velocity.y);
        
        else
            m_Rigidbody.velocity = new Vector2(0, m_Rigidbody.velocity.y);

        if (Mathf.Sign(Input.GetAxis("Horizontal")) != Mathf.Sign(f_LastAxis) && IsGrounded())
            m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, -1);


        f_LastAxis = Input.GetAxis("Horizontal");
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position /*+ new Vector3(0, -m_BodyCollider.size.y / 2 + 0.1f, 0)*/ + new Vector3(0,0.1f,0),
                                new Vector2(m_BodyCollider.size.x - 0.1f, 0.1f), 0, Vector2.down, 0.2f, layerMask);
        return hit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            b_Stop = true;
            m_Animator.SetInteger("animNr", 0);
        }

        if(collision.CompareTag("Item"))
        {
            string message = "Mmmh. a " + collision.name;
            string obj = (collision.name.Substring(0, collision.name.Length - 3)).TrimEnd();
            message = message.Substring(0, message.Length - 3).TrimEnd();
            print(obj);
            if(obj !="ring")
            {
                TextBubble.Create(textBubblePrefab, this.transform, new Vector3(0.5f, 2.1f, -76.3f),message);
                WorldComponents.m_items.Add(collision.name);
                if (obj == "healthpotion") {
                    WorldComponents.items.Add(new HealingPotion());
                } else if (obj == "manapotion") {
                    WorldComponents.items.Add(new MagicPotion());
                }
            }
            else
            {
                TextBubble.Create(textBubblePrefab, this.transform, new Vector3(0.5f, 2.1f, -76.3f), "Holy bananas I found it!\nNow I gotta give it back to him.. ");
                WorldComponents.m_items.Add(collision.name);
                WorldComponents.b_ringquest = true;
            }
            Destroy(GameObject.Find(collision.name));
        }
    }
}
