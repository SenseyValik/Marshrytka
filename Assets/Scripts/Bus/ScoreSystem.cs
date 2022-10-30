using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int currentScore;

    public float position;
    void Start()
    {
        currentScore = 0;
        position = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScore()
    {
        int difference = (int)(transform.position.z - position);
    }
}
