using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed; 
    private Rigidbody2D rig;
    private Animator anim;
    private bool IsJump;
    private bool doubleJump;
    public float jumpForce;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("IsAtack", true);
        }

        if (movement < 0)
        {
            anim.SetBool("IsRun", true);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (movement > 0)
        {
 
            anim.SetBool("IsRun", true);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
 
    }
    void Jump() 
    {
        if (Input.GetButtonDown("Jump"){
            if (!IsJump)
            {
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else
            {
                if(doubleJump)
                {
                    rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 8) 
        {
            IsJump = false;
        }
    }
}
