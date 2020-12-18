using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // start lunuches the game
    public void StartGame()
    {
        Debug.Log("pressed start");
        SceneManager.LoadScene("Loading Screen");
    }

    //quit quits the game (only works on build)
    public void Quit()
    {
        Debug.Log("pressed quit");
        Application.Quit();
    }
}
