using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour

{
    public float moveSpeed;

    public Transform leftPoint , rightPoint;

    public float moveTime, waitTime;
    private float moveCount, waitCount;
    private Rigidbody2D rb;
    public SpriteRenderer sr;
    private Animator anim;
    private bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
        leftPoint.parent = null;
        rightPoint.parent = null;
        movingRight = true;
        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;
            if (movingRight)
            {
                rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
                sr.flipX = true;

                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
                sr.flipX = false;

                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }


            }
            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }
            anim.SetBool("isMoving" , true);
        }
        else if (waitCount > 0) 
        { 
            waitCount -= Time.deltaTime;
            rb.linearVelocity = new Vector2(0f , rb.linearVelocity.y);

            if(waitCount <= 0)
            {
                moveCount = moveTime;
            }
            anim.SetBool("isMoving", false);

        }
    }
}
