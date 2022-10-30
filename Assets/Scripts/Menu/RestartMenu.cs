using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Race");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}