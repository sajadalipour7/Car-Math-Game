using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameScript : MonoBehaviour
{
    [SerializeField] Image progressBar;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(LoadAsyncOperation());
    }

    // Update is called once per frame
    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(StaticCode.levelToLoad);

        while (asyncOperation.progress < 1)
        {
            progressBar.fillAmount = asyncOperation.progress;
            yield return new WaitForEndOfFrame();
        }
    }

    
}
