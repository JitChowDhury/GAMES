using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{  
    public static PlayerController instance;

    public float moveSpeed;
    public Rigidbody2D rb;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatisGround;

    private bool canDoubleJump;
    private bool isHurt;

    private Animator anim;
    private SpriteRenderer sr;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    public float bounceForce;


    public bool stopInput;
    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        anim = GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();
    }


    void Update()

    {
        if (!Pausemenu.instance.isPaused && !stopInput )
        {
            if (knockBackCounter <= 0)
            {
                isHurt = false;
                rb.linearVelocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.linearVelocity.y);
                isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatisGround);
                if (isGrounded)
                {
                    canDoubleJump = true;
                }
                if (Input.GetButtonDown("Jump"))
                {
                    

                    if (isGrounded)
                    {
                        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                        AudioManager.instance.PlaySFX(4);
                    }
                    else
                    {
                        if (canDoubleJump)
                        {
                            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                            AudioManager.instance.PlaySFX(4);
                            canDoubleJump = false;
                        }
                    }
                }
                if (rb.linearVelocity.x < 0)
                {
                    sr.flipX = true;
                }
                else if (rb.linearVelocity.x > 0)
                {
                    sr.flipX = false;
                }
            }
            else
            {
                isHurt = true;
                knockBackCounter -= Time.deltaTime;
                if (!sr.flipX)
                {
                    rb.linearVelocity = new Vector2(-knockBackForce, rb.linearVelocity.y);
                }
                else
                {
                    rb.linearVelocity = new Vector2(knockBackForce, rb.linearVelocity.y);
                }

            }
        }
          

            anim.SetFloat("moveSpeed" , Mathf.Abs(rb.linearVelocity.x));
            anim.SetBool("isGrounded" , isGrounded);
            anim.SetBool("isHurt" , isHurt);
    }
    public void knockBack()
    {
        knockBackCounter = knockBackLength;
        rb.linearVelocity = new Vector2(0f , knockBackForce);
    }
    public void Bounce()
    {
        rb.linearVelocity=new Vector2(rb.linearVelocity.x , bounceForce);
    }
}
