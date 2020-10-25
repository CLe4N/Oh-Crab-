using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp_Con : MonoBehaviour
{
    public GameObject PopUp;

    public void PopUp_On()
    {
        PopUp.SetActive(true);
    }

    public void PopUp_Off()
    {
        PopUp.SetActive(false);
    }
}
