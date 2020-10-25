using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control_Ui : MonoBehaviour
{
    public bool conIsTouch;
    public GameObject joyStick;
    public GameObject BaseCon;
    public Vector3 clickPosition;
    Vector3 touchPosition;

    Vector3 Offset;
    Vector3 direction;

    Vector3 defultPos;

    void Start()
    {
        defultPos = joyStick.transform.position;
    }
    void Update()
    {
        JoyStick_Move();
    }
    void JoyStick_Move()
    {
        clickPosition = Input.mousePosition;
        Offset = defultPos - clickPosition;
        direction = Vector3.ClampMagnitude(Offset, 100.0f);
        if (conIsTouch == true)
        {
            joyStick.transform.position = new Vector3(defultPos.x + (direction.x*-1),defultPos.y + (direction.y*-1));
        }
        else
        {
            joyStick.gameObject.transform.position = defultPos;
        }
    }
    public void con_On()
    {
        conIsTouch = true;
    }
    public void con_Off()
    {
        conIsTouch = false;
    }
}
