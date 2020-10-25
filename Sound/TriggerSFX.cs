using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    public AudioSource SFX_sound;
    void Update()
    {
        
    }

    public void Trigger_Sound()
    {
        SFX_sound.Play();
    }
}
