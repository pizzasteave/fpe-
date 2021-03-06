﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public float fireRate;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }else
        {
            Debug.LogError("No Speed For The Projectile ! ");
        }


    
    }

    void OnCollisionEnter(Collision collision)
    {  
        speed = 0;
        Debug.Log("destroyed"); 
        Destroy(gameObject);
    }

   
}
