using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] bool IsItemCollect;
    public Slider Bar;
    public float MaxBarFloat;
    public bool TimeIsUp;
    public Player_health playerStat;
    int MaxStatInt;

    // Update is called once per frame
    void Update()
    {
        if (playerStat.death_state != true)
        {
            if (IsItemCollect == false)
            {
                Bar.value -= Time.deltaTime;
                if (Bar.value <= 0)
                {
                    TimeIsUp = true;
                }
            }
        }
    }
}
