using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class shooting_enemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public Player player;


    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // timer += Time.deltaTime;
        // if (timer > 2)
        // {
        //     timer = 0;
        //     shoot();
        // }
    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
    
    void OnCollisionStay2D(Collision2D col)
    {
        foreach (ContactPoint2D contact in col.contacts)
        {
            if (col.collider.CompareTag("Player"))
            {
                player.Damage();
            }
        }
    }
}
