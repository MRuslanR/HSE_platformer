using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;

    public int speed = 10;
    private bool isOnGround = false;
    public float jump_force = 10;

    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed, GetComponent<Rigidbody2D>().velocity[1]);
    }
    
    
    void Update()
    {
        //cam 
        cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(transform.position.x, transform.position.y, -10), Time.deltaTime * 5);

        // Move
        
        anim.SetFloat("moveX", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                isOnGround = false;
                anim.SetBool("Jumping", true);
                rb.AddForce(Vector2.up * jump_force,ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
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
        isOnGround = false;
        anim.SetBool("Jumping", true);
    }
}
