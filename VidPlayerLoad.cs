using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayerLoad: MonoBehaviour
{
    VideoPlayer vid;
    public AudioSource menu_bgm;
    public GameObject dummy;
    bool BGM_IsPlay;
    void Start()
    {
        vid = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if(vid.isPlaying == true)
        {
            dummy.SetActive(false);
            if (BGM_IsPlay == false)
            {
                menu_bgm.Play();
                BGM_IsPlay = true;
            }
        }
        else
        {
            dummy.SetActive(true);
        }
    }
}
