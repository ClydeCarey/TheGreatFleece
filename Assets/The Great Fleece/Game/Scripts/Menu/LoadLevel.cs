using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public Image progressBar;

    // Start is called before the first frame update
    void Start()
    {
        //call coroutine to load main scene
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        

        //create an async operation = loadsceneasync("main")
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");

        //while operation is ongoing
        while (operation.isDone == false)
        {
            //progress bar fill = operation progress
            progressBar.fillAmount = operation.progress;
            //yield wait for end of frame
            yield return new WaitForEndOfFrame();
        }       
        
    }
}
