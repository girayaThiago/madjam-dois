using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.Play("menuScreen");
    }

    public void Play()
    {
        AudioManager.instance.Stop("menuScreen");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // load next scene
    }



    public void Quit()
    {
        Application.Quit();
    }
}
