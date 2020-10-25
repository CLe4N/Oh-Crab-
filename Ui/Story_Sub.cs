using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story_Sub : MonoBehaviour
{
    Text Story_txt;
    public string Thai;
    public string Eng;
    public Sub_Ui EngStat;

    void Start()
    {
        Story_txt = GetComponent<Text>();
    }

    void Update()
    {
        if(EngStat.eng == true)
        {
            Story_txt.text = Eng;
        }
        else
        {
            Story_txt.text = Thai;
        }
    }
}
