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
        UpdateScore();
    }

    public void UpdateScore()
    {
        int difference = (int)(transform.position.z - lastPosition);
        print(difference);
        if (difference > 0)
        {
            currentScore += difference;
            lastPosition = transform.position.z;
            scoreIndicatorText.text = "Score: " + currentScore;
        }
    }

    public void SaveScoreIfHigher(int score)
    {
        int maxScore = GetMaxScore();
        if (score > maxScore)
            PlayerPrefs.SetInt("maxScore", score);
    }

    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("maxScore", 0);
    }
}
