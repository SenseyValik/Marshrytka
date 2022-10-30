using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public int currentScore;

    public float lastPosition;

    public Text scoreIndicatorText;
    void Start()
    {
        currentScore = 0;
        lastPosition = transform.position.z;

        scoreIndicatorText.text = "Score: " + currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScore()
    {
        int difference = (int)(transform.position.z - lastPosition);
        if (difference > 0)
        {
            currentScore += difference;
            scoreIndicatorText.text = "Score: " + currentScore;
        }
    }
}
