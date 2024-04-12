using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    private Rigidbody2D rb;
    private ParticleSystem pr;
    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        pr = GetComponent<ParticleSystem>();
    }


    private void Update()
    {
        if (!pr.IsAlive())
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.position += Vector2.down * Time.fixedDeltaTime * BlockHandler.moveSpeed;
    }
}
