using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    public Player_health death_check;
    public Ability_Ui hide_check;
    public Image hide_button;
    public bool Hidding;
    Animator anim;
    float CD_Timer;
    float CD_Start = 5.0f;
    bool CD_Active;

    float CooldownTimer;
    float CooldownStart = 4.0f;
    bool CooldownActive;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (death_check.death_state == false)
        {
     
            if (CooldownActive == false)
            {
                if (CD_Active == false)
                {
                    if (hide_check.abilityIsTouch == true)
                    {
                        In_Hide();
                        CD_Timer = CD_Start;
                        hide_button.color = new Color(140f / 255f, 140f / 255f, 140f / 255f, 233f / 255f);
                    }
                }
                else
                {
                    CD_Timer = CD_Timer - Time.deltaTime;
                    if (CD_Timer <= 0)
                    {
                        CooldownTimer = CooldownStart;
                        Out_Hide();
                    }
                }
            }
            else
            {
                CooldownTimer = CooldownTimer - Time.deltaTime;
                if (CooldownTimer <= 0)
                {
                    CD_Active = false;
                    hide_check.abilityIsTouch = false;
                    CooldownActive = false;
                    hide_button.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
                }
            }
        }
    }

    void In_Hide()
    {
        anim.SetBool("Hide", true);
        Hidding = true;
    }

    void Out_Hide()
    {
        anim.SetBool("Hide", false);
        Hidding = false;
    }

    void HideIsTrue()
    {
        CD_Active = true;
    }
    void CoolDownIsTrue()
    {
        CooldownActive = true;
    }
}
