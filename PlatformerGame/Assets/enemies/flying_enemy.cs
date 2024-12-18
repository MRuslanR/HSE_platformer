using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class flying_enemy : MonoBehaviour
{
    public float speed = 10f;
    float direction = -1f;
    public float distance = 300f;
    public bool isSyn = true;
    public Animator animator;
    private float x_way = 0;
    private float start_y = 0;
    private Vector3 start_scale;
    private int isMoving = 1;

    private void Start()
    {
        start_y = transform.position.y;
        start_scale = transform.localScale;
    }

    void FixedUpdate()
    {
        if (isMoving == 1)
        {
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(speed * direction, GetComponent<Rigidbody2D>().velocity.y);
            x_way += speed;
            if (x_way >= distance)
            {
                direction *= -1f;
                x_way = 0;
            }

            if (isSyn == true)
            {
                float yOffset = Mathf.Sin(transform.position.x);
                Vector3 pos = transform.position;
                pos.y = start_y + yOffset;
                transform.position = pos;
            }

            transform.localScale = new Vector3(direction * start_scale[0], start_scale[1], start_scale[2]);
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        foreach (ContactPoint2D contact in col.contacts)
        {
            if (col.collider.CompareTag("Player") && contact.normal.y < -0.7f)
            {
                GetComponent<Animator>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                isMoving = 0;
            }
            else if (col.collider.CompareTag("Player"))
            {
                var player = col.collider.GetComponent<Player>();
                if (player != null)
                {
                    player.Damage();
                }
            }
            if (contact.normal.x > 0.9f)
            {
                x_way = 0;
                direction = 1f;
                break;
            }
            else if (contact.normal.x < -0.9f)
            {
                x_way = 0;
                direction = -1f;
                break;
            }
        }
    }

}