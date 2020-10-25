using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Con : MonoBehaviour
{
    public Player_health death_check;
    public Ability_Ui Dash_Ui;
    public bool DashIsTrue;
    public AudioSource DashSFX;
    [SerializeField] float Dash_Speed;
    Rigidbody rb;
    Animator anim;
    float DashTimer;
    float DashStart = 0.2f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        DashTimer = DashStart;
    }
    void Update()
    {
        if (death_check.death_state == false)
        {
            if (Dash_Ui.abilityIsTouch == true)
            {
                if (DashTimer <= 0)
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, 0);
                    Dash_Ui.abilityIsTouch = false;
                    DashIsTrue = false;
                    anim.SetBool("Dash", false);
                }
                else
                {
                    rb.AddForce(transform.forward * Dash_Speed, ForceMode.Impulse);
                    anim.SetBool("Dash", true);

                    if(DashSFX.isPlaying == false)
                    {
                        DashSFX.Play();
                    }

                    DashIsTrue = true;
                    DashTimer = DashTimer - Time.deltaTime;
                }
            }
            else
            {
                DashTimer = DashStart;
            }
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }
}
