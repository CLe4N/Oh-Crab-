using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puffer_Event : MonoBehaviour
{
    public Puffer_Con con;
    public Puffer_Health health;
    public GameObject marker;
    public bool IsBackward;
    public float cooldown;
    public float new_cooldown;
    public AudioSource impact_sfx;
    public AudioSource falling_sfx;
    void Start()
    {
    }

    void Update()
    {
        if (health.IsWeak == true)
        {
            if (health.GotHit == false)
            {
                if (cooldown > 0)
                {
                    cooldown = cooldown - Time.deltaTime;
                }
                else
                {
                    health.IsWeak = false;
                    con.StopAttack();
                }
            }
            if(health.GotHit == true)
            {
                health.IsWeak = false;
                con.HurtAnim();
                con.StopAttack();
            }
        }
    }

    void AttackIsFinish()
    {
        cooldown = new_cooldown;
        impact_sfx.Play();
        marker.SetActive(false);
        health.IsWeak = true;
        con.IsKinetic();
    }

    void ReturnIsFinish()
    {
        cooldown = 0;
        health.IsWeak = false;
        con.PlayerDetect = false;
        health.GotHit = false;
        con.StopHurtAnim();
        con.IsNotKinetic();
        IsBackward = true;
        con.BackWardTime = 2;
    }

    public void Play_Falling_sfx()
    {
        falling_sfx.Play();
    }
}
