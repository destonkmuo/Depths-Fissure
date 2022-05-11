using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnIntroFinish : MonoBehaviour
{
    public bool loadedLevel = false;
    public void LoadLevel (int sceneIndex)
    {   

        StartCoroutine(LoadAsynchronously(sceneIndex));
    }   

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        if(!loadedLevel) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadedLevel = true;
        return null;
        }
        return null;
    }
}
