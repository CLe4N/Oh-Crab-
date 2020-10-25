using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Con : MonoBehaviour
{
    Animator anim;
    public bool attackIsTrue;
    public Dash_Con Dash_check;
    public Ability_Ui Attack_state;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Dash_check.DashIsTrue == false)
        {
            if (Attack_state.abilityIsTouch == true)
            {
                anim.SetBool("Attack", true);
                attackIsTrue = true;
            }
            else
            {
                anim.SetBool("Attack", false);
                attackIsTrue = false;
            }
        }
        else
        {
            anim.SetBool("Attack", false);
            attackIsTrue = false;
            Attack_state.abilityIsTouch = false;
        }

    }

    void Attack_End()
    {
        Attack_state.abilityIsTouch = false;
    }
}
