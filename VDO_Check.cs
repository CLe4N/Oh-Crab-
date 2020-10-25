using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VDO_Check : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject loadPanel;
    int videoIsPlaying;
    public LoadScene loadScene;

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
        loadPanel.SetActive(true);
    }

    void Update()
    {
        if(videoPlayer.isPlaying == true)
        {
            videoIsPlaying++;
            if(videoIsPlaying >= 10)
            {
                loadPanel.SetActive(false);
            }
        }
    }
    void EndReached(VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        loadPanel.SetActive(true);
        loadScene.loadNextScene();
    }
}
