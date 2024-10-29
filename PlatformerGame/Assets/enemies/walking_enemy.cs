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
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction, GetComponent<Rigidbody2D>().velocity.y);
        transform.localScale = new Vector3(direction, 1, 0);

    }
    void OnCollisionStay2D(Collision2D col)
    {
        foreach (ContactPoint2D contact in col.contacts)
        {
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