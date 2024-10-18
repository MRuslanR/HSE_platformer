using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public int speed = 10;
    private bool isOnGround = false;
    private Vector3 _groundCheckOffset = new Vector3(0, 0.5f, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal")*speed,GetComponent<Rigidbody2D>().velocity[1]);
        anim.SetFloat("moveX", Mathf.Abs(Input.GetAxis("Horizontal")));
        
        if (Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                isOnGround = false;
                anim.SetBool("Jumping", true);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5f,ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.9f)
            {
                isOnGround = true;
                anim.SetBool("Jumping", false);
            }
        }
    }
    
    
    void OnCollisionExit2D(Collision2D collision)
    {
        // isOnGround = false;
        // foreach (ContactPoint2D contact in collision.contacts)
        // {
        //     if (contact.normal.y > 0.9f)
        //     {
        //         isOnGround = true;
        //     }   
        // }
    }
}
