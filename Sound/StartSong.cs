using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSong : MonoBehaviour
{
    public AudioSource Song_play;

    private void Start()
    {
        Song_play.Play();
    }
}
