using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SFX : MonoBehaviour
{
    public AudioSource move_sfx;
    public AudioSource hit_sfx;
    public AudioSource dash_sfx;
    
    void play_hit()
    {
        hit_sfx.Play();
    }
    void play_move()
    {
        move_sfx.Play();
    }
    void play_dash()
    {
        dash_sfx.Play();
    }
}
