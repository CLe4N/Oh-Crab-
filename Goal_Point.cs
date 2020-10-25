using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Point : MonoBehaviour
{
    public GameObject StageClearIcon;
    public GameObject GoalText;
    public AudioSource WinSFX;
    public AudioSource StageBGM;
    public Control_Ui con;
    public Score_UI score;
    public LoadScene loadNextScene;
    public bool PlayerIsWin;
    public bool finalGoal;

    void Start()
    {
        
    }
    void Update()
    {
        if (PlayerIsWin == true)
        {
            con.conIsTouch = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (finalGoal == false)
        {
            if (score.readyToWin == true)
            {
                if (other.tag == "Player")
                {
                    StageClearIcon.SetActive(true);
                    WinSFX.Play();
                    StageBGM.Stop();
                    PlayerIsWin = true;
                    Invoke("GoNextScene", 5.0f);

                }
            }

            else
            {
                GoalText.SetActive(true);
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                GoNextScene();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GoalText.SetActive(false);
        }
    }

    void GoNextScene()
    {
        loadNextScene.loadNextScene();
    }
}
