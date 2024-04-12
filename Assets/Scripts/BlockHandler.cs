using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    private Transform env;
    private float threshold;
    private Rigidbody2D rb;
    public static float moveSpeed = 2f;
    public static bool fall = false;
    private float startTime;
    void Start()
    {
        env = GameObject.Find("Background").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        threshold = -env.localScale.y / 2;

        if (transform.position.y + 0.25 < threshold)
        {
            Destroy(gameObject);
        }

        if (fall)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }

    }

    private void FixedUpdate()
    {
        
        rb.position += Vector2.down * Time.fixedDeltaTime * moveSpeed;
    }
}
