using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadLevel : MonoBehaviour
{
    [SerializeField] int levelIndex;
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    
    // Start is called before the first frame update
    public void LoadThisLevel()
    {
        StaticCode.levelToLoad = levelIndex;
        SceneManager.LoadScene(2);
    }
}
