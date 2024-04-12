using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inGamePoints;
    public GameObject highScoreObj;
    
    private TextMeshProUGUI highScoreText;
    private TextMeshProUGUI inGamePointsText;
    private TextMeshProUGUI endPointsText;
    
    private float points;
    private float zero;
    private float zero2;
    private float highScore;
    void Start()
    {
        inGamePointsText = inGamePoints.GetComponent<TextMeshProUGUI>();
        highScoreText = highScoreObj.GetComponent<TextMeshProUGUI>();
        endPointsText = gameObject.GetComponent<TextMeshProUGUI>();
        inGamePoints.GetComponent<PointUI>().enabled = false;
        points = PointHandler.points;
        
        zero = 0;
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", 0f);
        }

        highScore = PlayerPrefs.GetFloat("HighScore");
        if (points > highScore)
        {
            highScore = points;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (points != 0)
        {
            zero += 5;
            points -= 5;
            
        }

        if (zero2 < highScore)
        {
            zero2 += 5;
        }
        if (zero > PointHandler.points)
        {
            zero = PointHandler.points;
        }

        if (zero2 > highScore)
        {
            zero2 = highScore;
        }

        if (points < 0)
        {
            points = 0;
        }

        inGamePointsText.text = points.ToString();
        endPointsText.text = zero.ToString();
        highScoreText.text = zero2.ToString();
    }
    

}
