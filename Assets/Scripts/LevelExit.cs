using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{   
    [SerializeField] float levelLoadDelay = 1f;
    void OnTriggerEnter2D(Collider2D other) 
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentIndexScene = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentIndexScene + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

            FindObjectOfType<ScenePersist>().resetScenePersist();
            SceneManager.LoadScene(nextSceneIndex);
    }
}
