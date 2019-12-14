using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    void Pause()
    {
        GameIsPaused = true;
        Time.timeScale = 0.0f;
        PauseMenuUI.SetActive(true);
    }

    void Resume()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        PauseMenuUI.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quite()
    {
        Application.Quit();
    }
}
