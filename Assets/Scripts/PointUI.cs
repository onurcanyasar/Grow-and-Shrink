using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointUI : MonoBehaviour
{
    private TextMeshProUGUI points;
    void Start()
    {
        points = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        points.text = PointHandler.points.ToString();
    }
}
