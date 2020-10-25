using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySlide_con : MonoBehaviour
{
    public GameObject Previos_Slider;
    public GameObject Next_Slider;
    public GameObject This_Slider;
    public GameObject LoadPanel;
    bool alreadyLoad;
    public string NextScene_Name;

    void Start()
    {
        
    }
    public void Go_Next_slide()
    {
        if (Next_Slider != null)
        {
            Next_Slider.SetActive(true);
            This_Slider.SetActive(false);
        }
        else
        {
            LoadPanel.SetActive(true);
            Invoke("loadNextScene", 0.1f);
        }
    }

    public void Go_Previos_slide()
    {
        Previos_Slider.SetActive(true);
        This_Slider.SetActive(false);
    }

    void loadNextScene()
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
