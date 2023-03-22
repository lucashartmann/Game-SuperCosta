using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed = 4;
    private Rigidbody2D rig;
    private Animator anim;
    private bool isJumping;
    private bool doubleJump;
    private float jumpForce = 4.3f;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
        Atack();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

 
        if (movement > 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 2);
            }
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 2);
            }
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if(movement == 0 && !isJumping)
        {
            anim.SetInteger("transition", 0);
        }

    }
    void Jump() 
    {
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetInteger("transition", 1);
            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                isJumping = true;
            }
            else
            {
                if(doubleJump)
                {
                    anim.SetInteger("transition", 1);
                    rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void Atack()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 3);
            }

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 8) 
        {
            isJumping = false;
        }

    }
}
