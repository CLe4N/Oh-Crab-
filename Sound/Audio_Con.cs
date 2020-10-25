using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio_Con : MonoBehaviour
{
    public Slider BG_Con;
    public Slider FX_Con;

    public AudioSource[] BG_clip;
    public AudioSource[] FX_clip;
    void Start()
    {
        
    }

    void Update()
    {
        for (int j = 0; j < BG_clip.Length; j++)
        {
            BG_clip[j].volume = BG_Con.value;
        }
        for (int i = 0; i < FX_clip.Length; i++)
        {
            FX_clip[i].volume = FX_Con.value;
        }

    }
}
