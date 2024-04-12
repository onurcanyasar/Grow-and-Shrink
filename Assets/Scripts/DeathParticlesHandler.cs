using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeathParticlesHandler : MonoBehaviour
{
    private Rigidbody rb;
    private int rand;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rand = Random.Range(0, 4);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    private void FixedUpdate()
    {
       
        
        //rb.AddTorque(2f);
        //Vector2 force = new Vector2();
        //force = transform.right * 10 + transform.up * 10; 
        //rb.AddForce(force + (Vector2)transform.up*10);
        rb.AddExplosionForce(5f, transform.position, 5f);
    /*
        switch (rand)
        {
            case 0:
                force = Vector2.up * 15;
                break;
            case 1:
                force = Vector2.right * 10;
                break;
            case 2:
                force = Vector2.left * 10;
                break;
            case 3:
                force = Vector2.down * 15;
                break;
            
        }
        rb.AddForce(force + Vector2.up * 10);
        */
    }
    
}
