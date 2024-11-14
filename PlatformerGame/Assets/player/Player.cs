using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using UnityEngine.SceneManagement;
using System. Threading;

public class Player : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;

    public int speed = 10;
    private bool isOnGround = false;
    public float jump_force = 10;
    public Image hp_bar;
    public TextMeshProUGUI GameOver;

    public Camera cam;
    
    private int damage_timer = 0;
    private int death_timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (damage_timer > 0)
        {
            if (damage_timer % 2 == 0)
            {
                Color color = GetComponent<SpriteRenderer>().material.color;
                if (color.a == 0.25f)
                {
                    color.a = 1.0f;
                }
                else
                {
                    color.a = 0.25f;
                }
                GetComponent<SpriteRenderer>().material.color = color;
            }
            damage_timer -= 1;
        }
        else
        {
            Color color = GetComponent<SpriteRenderer>().material.color;
            color.a = 1.0f;
            GetComponent<SpriteRenderer>().material.color = color;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed, GetComponent<Rigidbody2D>().velocity[1]);
    }

    public void Damage()
    {
        if (damage_timer == 0)
        {
            hp_bar.fillAmount -= 0.33f;
            damage_timer += 20;

            if (hp_bar.fillAmount <= 0.1)
            {
                GameOver.enabled = true;
                Time.timeScale = 0f;

            }
        }

    }


    
    void Update()
    {
        //cam
        cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(transform.position.x, transform.position.y, -10), Time.deltaTime * 5);

        // Movedd
        
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
        if (GameOver.enabled ){
            if (death_timer < 100){
                death_timer += 10;
            }
            else{
                Thread.Sleep(3000);
                Time.timeScale = 1f;
                SceneManager.LoadScene("Level_" + PlayerPrefs.GetInt("PlayerLevel").ToString());
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
