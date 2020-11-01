using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentScript : MonoBehaviour
{
    GameObject gameOverPanel;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        gameOverPanel = GameObject.FindGameObjectWithTag("Finish");
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
        GetComponentInChildren<ParticleSystem>().Play();
        StartCoroutine("TimeScaleChanger");
        gameOverPanel.transform.GetChild(0).gameObject.SetActive(true);
       
      
        
    }

    IEnumerator TimeScaleChanger()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
    }
}
