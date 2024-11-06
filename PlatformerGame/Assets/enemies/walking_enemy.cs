using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class walking_enemy : MonoBehaviour
{
    public float speed = 1f;
    float direction = -1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction, GetComponent<Rigidbody2D>().velocity.y);
        transform.localScale = new Vector3(direction, 1, 0);

    }
    void OnCollisionStay2D(Collision2D col)
    {
        foreach (ContactPoint2D contact in col.contacts)
        {
            if (col.collider.CompareTag("Player") && contact.normal.y < -0.7f)
            {
                print("Есть пробитие");
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
                direction = 1f;
                break;
            }
            else if (contact.normal.x < -0.9f)
            {
                direction = -1f;
                break;
            }
        }
    }

}