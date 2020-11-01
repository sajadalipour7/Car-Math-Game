using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerCheck : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    [SerializeField] int TimerSet = 31;
    [SerializeField] GameObject gameOverPanel;

    int timeNow;
    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Time.timeScale = 1;
        textMesh=GetComponent<TextMeshProUGUI>();
        timeNow = TimerSet;
        StartCoroutine("TimerTick");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeNow <=0)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }

    IEnumerator TimerTick()
    {
        for (int i = 0; i < TimerSet; i++)
        {
            timeNow--;
            textMesh.text = "TIME : " + timeNow.ToString() + " S";
            
            yield return new WaitForSeconds(1f);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
