using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid_Target : MonoBehaviour
{
    [SerializeField] float closeDis;
    [SerializeField] float longDis;

    public bool squid_detect;
    public bool squid_attack_stat;
    public Transform player;
    public Squid_Con squid;
    public WayP_Squid wayP;
    float PlayerDis = Mathf.Infinity;

    public AudioSource alert_sound;
    public Hide hide_stat;

    void Start()
    {
        
    }

    void Update()
    {
        if (squid.Squid_Hp > 0)
        {
            DetectPlayer();
            playerCheck();
        }
        else
        {
            squid.Dying_squid();
        }
    }

    void OnDrawGizmosSelected()
    {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, closeDis);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, longDis);
    }

    void DetectPlayer()
    {
        if (hide_stat == null)
        {
            PlayerDis = Vector3.Distance(player.position, transform.position);

            if (PlayerDis <= longDis)
            {
                squid_detect = true;

                if (PlayerDis <= closeDis)
                {
                    squid_attack_stat = true;
                }

                else
                {
                    squid_attack_stat = false;
                }
            }

            else
            {
                squid_detect = false;
            }
        }
        else
        {
            if (hide_stat.Hidding == false)
            {
                PlayerDis = Vector3.Distance(player.position, transform.position);

                if (PlayerDis <= longDis)
                {
                    squid_detect = true;

                    if (PlayerDis <= closeDis)
                    {
                        squid_attack_stat = true;
                    }

                    else
                    {
                        squid_attack_stat = false;
                    }
                }

                else
                {
                    squid_detect = false;
                }
            }
            else
            {
                squid_detect = false;
            }
        }
    }

    void playerCheck()
    {
        if(squid_detect == true)
        {
            squid.Look_Target();
            squid.Squid_move();
            squid.Squid_stop_attack();
            alert_sfx();
            if (squid_attack_stat == true)
            {
                squid.Squid_Attack();
                squid.Look_Target();
            }
        }
        else
        {
            wayP.Waypoint_move();
        }
    }

    void alert_sfx()
    {
        if (alert_sound.isPlaying == false)
        {
            alert_sound.Play();
        }
    }
}

