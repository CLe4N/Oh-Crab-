using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayP_Squid : MonoBehaviour
{
    public Transform[] Waypoint;
    public Squid_Target squid_detect_stat;
    int WPoint_No;
    Vector3 Wpoint_Angle;
    Squid_Con squid;
    Animator anim;

    void Start()
    {
        squid = GetComponent<Squid_Con>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //Waypoint_move();
    }

    public void Waypoint_move()
    {
        if (Waypoint.Length > 1)
        {
                transform.LookAt(Waypoint[WPoint_No].position);
                transform.position = Vector3.MoveTowards(transform.position, Waypoint[WPoint_No].position, (squid.Squid_speed * 2) * Time.deltaTime);
                squid.Squid_move();
                anim.SetBool("Walk", true);
            if (Vector3.Distance(transform.position, Waypoint[WPoint_No].position) < 0.1f)
            {
                WPoint_No++;
                if (WPoint_No == Waypoint.Length)
                {
                    WPoint_No = 0;
                }
            }
        }

        else if (Waypoint.Length <= 1)
        {
            transform.LookAt(Waypoint[WPoint_No].position);
            transform.position = Vector3.MoveTowards(transform.position, Waypoint[WPoint_No].position, (squid.Squid_speed * 2) * Time.deltaTime);
            anim.SetBool("Walk", true);
            if (Vector3.Distance(transform.position, Waypoint[WPoint_No].position) < 0.1f)
            {
                squid.origin_Squid();
            }
        }
    }
}
