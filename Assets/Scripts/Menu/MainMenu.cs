using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text maxScoreText;
    private void Start()
    {
        int maxScore = PlayerPrefs.GetInt("maxScore", 0);
        if (maxScore > 0)
            maxScoreText.text = "Max score: " + maxScore;
        else
            maxScoreText.text = "Get ready!";
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Race");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
