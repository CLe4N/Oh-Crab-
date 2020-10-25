using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sub_Ui : MonoBehaviour
{
    public Save_con Sub_data;
    public Image Thai_BT;
    public Image Eng_BT;
    public bool eng;
    void Update()
    {
        Sub_data.data.SubIsThai = eng;
        if(eng == false)
        {
            Thai_BT.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            Eng_BT.color = new Color(140f / 255f, 140f / 255f, 140f / 255f, 233f / 255f);
        }
        if(eng == true)
        {
            Thai_BT.color = new Color(140f / 255f, 140f / 255f, 140f / 255f, 233f / 255f);
            Eng_BT.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        }
    }

    public void Eng_IsActive()
    {
        eng = true;
    }

    public void Thai_IsActive()
    {
        eng = false;
    }

    public void load_Sub()
    {
        eng = Sub_data.data.SubIsThai;
    }
}
