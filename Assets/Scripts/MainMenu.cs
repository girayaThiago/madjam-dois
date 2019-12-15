using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.Play("menuScreen");
        AudioManager.instance.Stop("tutorial");
        AudioManager.instance.Stop("distantSignal");

    }

    public void Play()
    {
        AudioManager.instance.Stop("menuScreen");
        AudioManager.instance.Play("tutorial");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // load next scene
    }



    public void Quit()
    {
        Application.Quit();
    }
}
