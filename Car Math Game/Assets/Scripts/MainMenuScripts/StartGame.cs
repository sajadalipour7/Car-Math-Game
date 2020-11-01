using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    

    public void ExitGame()
    {
        Application.Quit();
    }
}
