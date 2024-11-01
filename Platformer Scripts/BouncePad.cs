using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    private Animator anim;

    public float bounceForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController.instance.rb.linearVelocity = new Vector2(PlayerController.instance.rb.linearVelocity.x, bounceForce);
            anim.SetTrigger("Bounce");
        }
    }
}
