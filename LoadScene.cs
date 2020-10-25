using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    string ThisScene_Name;
    public string NextScene_Name;
    bool alreadyLoad;
    void Start()
    {
        ThisScene_Name = SceneManager.GetActiveScene().name;
    }

    public void loadThisScene()
    {
        if (ThisScene_Name != "Stag03(Puffer)")
        {
            SceneManager.LoadScene(ThisScene_Name);
        }

        else
        {
            NextScene_Name = "Stag02(Coral)";
            loadNextScene();
        }
    }

    public void loadNextScene()
    {
        if (alreadyLoad == false)
        {
            StartCoroutine(LoadAsync_NextScene());
        }
    }

    IEnumerator LoadAsync_NextScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(NextScene_Name);
        alreadyLoad = true;
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
