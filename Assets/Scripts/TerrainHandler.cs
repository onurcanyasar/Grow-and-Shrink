using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainHandler : MonoBehaviour
{
    public GameObject block;
    public Transform player;
    private float leftBound;
    private float rightBound;
    private float heightBound;
    private bool stat = false;
    private List<GameObject> blocks;
    private List<Rigidbody2D> rbs;
    public float moveSpeed = 1f;
    private float yOffset;
    private float width;
    public static int point;
    private float maxWidth;
    private float minWidth;
    private float playerOffset;
    private float currTime;
    private float initTime;
    public static float elapsedTime;
    private bool pointsAdded;
    public GameObject borderYellow;
    public GameObject borderYellowY;
    public GameObject borderRed;
    public GameObject borderRedY;
    public GameObject borderBlue;
    public GameObject borderBlueY;
    public GameObject borderPink;
    public GameObject borderPinkY;
    public GameObject particles;
    private GameObject border;
    private GameObject borderY;
    private int rand;
    public static bool isAlive;
    private SpriteRenderer sr;
    void Start()
    {
        blocks = new List<GameObject>();
        rbs = new List<Rigidbody2D>();
        yOffset = -block.transform.localScale.y / 2;
        initTime = Time.time;
        playerOffset = 0.65f;
        point = 0;
        pointsAdded = false;
        border = null;
        borderY = null;
        isAlive = true;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            elapsedTime = Time.time - initTime;
        
            heightBound = transform.localScale.y / 2;
            leftBound = -transform.localScale.x / 2;
            rightBound = transform.localScale.x / 2;
            width = transform.localScale.x;
            maxWidth = (transform.localScale.x * 70) / 100;
            minWidth = (transform.localScale.x * 10) / 100;

            if (!stat)
            {
                currTime = Time.time;
                BlockHandler.moveSpeed += elapsedTime / 1000;
                proceduralGenerate();
                stat = true;
            }

            if (Time.time - currTime > 3.0f - elapsedTime / 100)
            {
                stat = false;
            }

           
        }
        
        
        
        
    }



  
    void instantiateLeft(float blockLength)
    {
        
        block.transform.localScale = new Vector3(blockLength, 0.5f, 1);
        float xOffset = block.transform.localScale.x / 2;
        float borderXOffset = borderY.transform.localScale.x / 2;
        blocks.Add(Instantiate(block, new Vector2(leftBound + xOffset, heightBound + yOffset), Quaternion.identity));
        //borderYellow.transform.localScale = new Vector3(blockLength, 0.1f, 1);
        
        border.transform.localScale = new Vector3(blockLength, 0.1f, 1);
        
        Instantiate(border, new Vector2(leftBound + xOffset, heightBound + yOffset + 0.25f), Quaternion.identity);
        Instantiate(border, new Vector2(leftBound + xOffset, heightBound + yOffset - 0.25f), Quaternion.identity);
        Instantiate(borderY, new Vector2(leftBound + 2 * xOffset - borderXOffset, heightBound + yOffset), Quaternion.identity);
    }

    void instantiateRight(float blockLength)
    {
        block.transform.localScale = new Vector3(blockLength, 0.5f, 1);
        //borderYellow.transform.localScale = new Vector3(blockLength, 0.1f, 1);
        float xOffset = block.transform.localScale.x / 2;
        float borderXOffset = borderY.transform.localScale.x / 2;
        blocks.Add(Instantiate(block, new Vector2(rightBound - xOffset, heightBound + yOffset), Quaternion.identity));
        border.transform.localScale = new Vector3(blockLength, 0.1f, 1);
        Instantiate(border, new Vector2(rightBound - xOffset, heightBound + yOffset + 0.25f), Quaternion.identity);
        Instantiate(border, new Vector2(rightBound - xOffset, heightBound + yOffset - 0.25f), Quaternion.identity);
        Instantiate(borderY, new Vector2(rightBound - 2 * xOffset + borderXOffset, heightBound + yOffset), Quaternion.identity);
    }

    void proceduralGenerate()
    {
        float widthLeft = Random.Range(minWidth, maxWidth);
        
        float widthRight = Random.Range(minWidth, width - widthLeft - playerOffset);
        chooseBorder();
        instantiateLeft(widthLeft);
        instantiateRight(widthRight);
        
    }

    void chooseBorder()
    {
        int rand = Random.Range(0, 4);
       
        
        switch(rand) 
        {
            case 0:
                border = borderYellow;
                borderY = borderYellowY;
                break;
            case 1:
                border = borderRed;
                borderY = borderRedY;
                break;
            case 2:
                border = borderBlue;
                borderY = borderBlueY;
                break;
            case 3:
                border = borderPink;
                borderY = borderPinkY;
                break;
        }
      
    }

    public static void finishGame()
    {
        BlockHandler.moveSpeed = 0;
        
        isAlive = false;

    }

  
    
}
