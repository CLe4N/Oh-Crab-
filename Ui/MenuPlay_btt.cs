

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPlay_btt: MonoBehaviour
{
    public Save_con Get_data;
    public GameObject Continue_window;
    public LoadScene NoSave;
    public GameObject LoadPanel;
    void open_Continue_window()
    {
        Continue_window.gameObject.SetActive(true);
    }

    public void close_Continue_window()
    {
        Continue_window.gameObject.SetActive(false);
    }

    public void Save_check()
    {
        if (Get_data.data.Scen_name != "")
        {
            Continue_window.gameObject.SetActive(true);
        }
        else
        {
            LoadPanel.SetActive(true);
            NoSave.loadNextScene();
        }
    }
}
