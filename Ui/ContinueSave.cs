using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueSave : MonoBehaviour
{
    string NextSceneName;
    public Save_con get_data;
    public GameObject loadPanel;
    bool alreadyLoad;
    public void Continue_Yes()
    {
        loadPanel.SetActive(true);
        NextSceneName = get_data.data.Scen_name;
        loadNextScene();
    }

    public void Continue_No()
    {
        loadPanel.SetActive(true);
        NextSceneName = "CutScene01";
        loadNextScene();
        get_data.data.Scen_name = "Stage01(SeaGrass)";
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
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(NextSceneName);
        alreadyLoad = true;
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
