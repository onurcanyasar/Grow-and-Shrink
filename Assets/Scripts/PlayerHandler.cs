using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private float screenWidth;
    private Rigidbody2D rb;
    public float moveSpeed = 1f;
    public float growSpeed = 1f;
    private GameObject background;
    public GameObject centerPointer;
   
    private Rigidbody2D centerPointerRb;
    
    private bool right = false;
    private bool left = false;
    private bool grow = false;
    private bool shrink = false;

    public GameObject gameOver;
    public GameObject restart;
    public List<GameObject> deads;
    private SpriteRenderer sr;
    private bool isAlive;
    private float startTime;
    private bool isInvoked;
    public GameObject explosion;
   
    private bool isShaked;
    private bool isShakeFinished;
    private bool isShakeStarted;
    private Animator anim;
    private BoxCollider2D col;

    public List<GameObject> components;
    void Start()
    {
        gameOver.SetActive(false);
        restart.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        background = GameObject.Find("Background");
        centerPointerRb = centerPointer.GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        isAlive = true;
        startTime = Time.time;

        isInvoked = false;
        isShaked = false;
        isShakeStarted = false;
        isShakeFinished = false;
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();

    }

    

    // Update is called once per frame
    void Update()
    {   
        screenWidth = background.transform.localScale.x;
        float currX = transform.position.x;
        float offset = transform.localScale.x / 2;  
        float boundLower = -screenWidth / 2;
        float boundHigher = screenWidth / 2;

        if (isAlive)
        {
            if ((Input.GetKey(KeyCode.W) || grow) && currX + offset < boundHigher && currX - offset > boundLower)
            {

    
                transform.localScale += new Vector3(1, 0, 0) * Time.deltaTime * growSpeed;
          
            }

            if ((Input.GetKey(KeyCode.S) || shrink) && offset * 2 > 0.5f)
            {
          
                transform.localScale -= new Vector3(1, 0, 0) * Time.deltaTime * growSpeed;
       
            }

            if ((Input.GetKey(KeyCode.A) || left) && currX - offset > boundLower)
            {
                rb.position -= new Vector2(1, 0) * Time.deltaTime * moveSpeed;
                centerPointerRb.position -= new Vector2(1, 0) * Time.deltaTime * moveSpeed;
           
            
            }

            if ((Input.GetKey(KeyCode.D) || right) && currX + offset < boundHigher)
            {
            
                rb.position += new Vector2(1, 0) * Time.deltaTime * moveSpeed;
                centerPointerRb.position += new Vector2(1, 0) * Time.deltaTime * moveSpeed;
            }

            if (transform.localScale.x < 0.5f)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0);
            }
        }
        else
        {
            
            if (transform.localScale.x > 0.5)
            {
                float currTime = Time.time;
                if (currTime - startTime > 0.01f)
                {
                    transform.localScale -= new Vector3(0.06f, 0, 0);
                    startTime = Time.time;
                }
            }
            else if(!isShaked)
            {
                BlockHandler.fall = true;
                anim.SetTrigger("Shake");
                isShaked = true;

            }
            else if (!isShakeStarted)
            {
                isShakeStarted = anim.GetCurrentAnimatorStateInfo(0).IsName("CubeShake");
            }
            else if (!isShakeFinished)
            {

                isShakeFinished = anim.GetCurrentAnimatorStateInfo(0).IsName("Idle");
                
            }
            else if(!isInvoked)
            {
                finishGame();
                isInvoked = true;
            }
        }
        
        
        
    
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isAlive = false;
        col.enabled = false;
        TerrainHandler.finishGame();
    }

    public void moveRight()
    {
        right = true;
    }

    public void moveRightReset()
    {
        right = false;
        
    }

    public void moveLeft()
    {
        left = true;
    }
    
    public void moveLeftReset()
    {
        left = false;
    }
    
    public void useGrow()
    {
        grow = true;
    }
    public void growReset()
    {
        grow = false;
    }
    public void useShrink()
    {
        shrink = true;
    }
    public void shrinkReset()
    {
        shrink = false;
    }
    
    void PauseGame ()
    {
        Time.timeScale = 0;
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
    }

    private void endScreen()
    {
        
     
        restart.SetActive(true);
        activateComponents();
        
        
        
    }

    private void activateComponents()
    {
        foreach (GameObject component in components)
        {
            component.SetActive(true);
        }
    }
    
    

   
    private void deathAnimation()
    {
        

        sr.enabled = false;
        foreach (GameObject dead in deads)
        {
            dead.SetActive(true);
        }
        explosion.SetActive(true);
    }

    private void finishGame()
    {
        deathAnimation();
        Invoke(nameof(endScreen), 1f);
    }
    
}
