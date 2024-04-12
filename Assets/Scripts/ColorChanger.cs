using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer sr;
    private List<Color> colors;
    private float startTime;
    private float currTime;
    private Color color;
    private bool isColorChanged;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        Color color = new Color(0.1882353f,0.1882353f,0.1882353f, 1);
        Color sand = new Color(141f/255f, 137f/255f, 128f/255f, 255f/255f);
        Color darkBlue = new Color(34f/255f, 32f/255f, 53f/255f, 255f/255f);
        Color brownie = new Color(143f/255f, 112f/255f, 75f/255f, 255f/255f);
        Color greeny = new Color(68f/255f, 120f/255f, 106f/255f, 255f/255f);
        Color blueLike = new Color(47f/255f, 64f/255f, 77f/255f, 255f/255f);
        colors = new List<Color>();
        colors.Add(color);
        colors.Add(sand);
        colors.Add(darkBlue);
        colors.Add(brownie);
        colors.Add(greeny);
        colors.Add(blueLike);
        startTime = Time.time;
        isColorChanged = false;

    }
    
    void Update()
    {
        currTime = Time.time;

        if (currTime - startTime > 5f)
        {
            int rand = Random.Range(0, colors.Count);
            color = colors[rand];
            
            startTime = Time.time;
            isColorChanged = true;
        }


        if (isColorChanged)
        {
            sr.color = Color.Lerp(sr.color, color, 0.05f);
            if (sr.color.Equals(color))
            {
                isColorChanged = false;
            }
        }
        
        

    }
    
    void changeColor(Color color)
    {
    
        

    }
}
