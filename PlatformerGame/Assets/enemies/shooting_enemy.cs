using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class shooting_enemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;


    private float timer;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}