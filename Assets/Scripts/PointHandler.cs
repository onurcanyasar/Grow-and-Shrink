using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointHandler : MonoBehaviour
{   
    private float leftOffset = 1;
    private float rightOffset = 1;
    public static int points = 0;

    private bool pointsAdded = false;

    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void FixedUpdate()
    
    {   
        float rightX = transform.localScale.x / 2 + transform.position.x;
        float leftX = -transform.localScale.x / 2 + transform.position.x;
        float pointDivider = (leftOffset + rightOffset) * 5 + 5;
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(rightX, transform.position.y), transform.right);
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(leftX, transform.position.y), -transform.right);



        if (TerrainHandler.isAlive)
        {
            if (hitLeft.collider != null && hitRight.collider != null)
            {
                if(hitLeft.collider.tag.Equals("Block") && hitRight.collider.tag.Equals("Block"))
                {
                
                    leftOffset = hitLeft.distance;
                    rightOffset = hitRight.distance;
                    if (leftOffset <= 0)
                    {
                        leftOffset = 1;
                    }

                    if (rightOffset <= 0)
                    {
                        rightOffset = 1;
                    }
                    pointDivider = (leftOffset + rightOffset) * 5 + 5;
                    int particlesRightCount = (int) (20 / (rightOffset * 5 + 1));
                    int particlesLeftCount = (int) (20 / (leftOffset * 5 + 1));
                    if (!pointsAdded)
                    {
                        addPoints(pointDivider);
                        pointsAdded = true;
                        GameObject clone = Instantiate(particles, new Vector3(hitLeft.point.x, hitLeft.point.y , 0), Quaternion.Euler(0, 0, 0));
                        clone.GetComponent<ParticleSystem>().emission.SetBurst(0, new ParticleSystem.Burst(0f, particlesLeftCount));
                    
                        clone = Instantiate(particles, new Vector3(hitRight.point.x, hitRight.point.y , 0) , Quaternion.Euler(0, 0, 0));
                        clone.GetComponent<ParticleSystem>().emission.SetBurst(0, new ParticleSystem.Burst(0f, particlesRightCount));

                    }
                }
                else
                {
                    pointsAdded = false;
                }
            
            }
            else
            {
                pointsAdded = false;
            }
        }
        
        
        
        
        
        
        
        
    }
    void addPoints(float divider)
    {
        points += (int) (1000 / divider) ;
    }
}
