using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop_UI : MonoBehaviour
{
    public GameObject Pause_UI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0f;
    }


    public void TimeIsStart()
    {
        Time.timeScale = 1f;
        Pause_UI.SetActive(false);
    }
}
