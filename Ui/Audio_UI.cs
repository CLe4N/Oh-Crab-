using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio_UI : MonoBehaviour
{
    public Save_con Volume_data;

    public Slider BG;
    public Slider Fx;

    void Update()
    {
        Volume_data.data.BG_Volume = BG.value;
        Volume_data.data.FX_Volume = Fx.value;
    }
    public void volume_load()
    {
        BG.value = Volume_data.data.BG_Volume;
        Fx.value = Volume_data.data.FX_Volume;
    }
}
