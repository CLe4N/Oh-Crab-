using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayP_move : MonoBehaviour
{
    public Transform[] Waypoint;
    int WPoint_No;
    Vector3 Wpoint_Angle;
    Rigidbody rb;
    GrndEnemy_Con Crab;
    Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Crab = GetComponent<GrndEnemy_Con>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
    }

    public void Waypoint_move()
    {
        if (Waypoint.Length <= 1)
        {
            if (Vector3.Distance(transform.position, Waypoint[0].position) < 0.1f)
            {
                Crab.origin_stage();
                anim.SetBool("Attack", false);
            }
            else
            {
                transform.LookAt(Waypoint[0].position);
                transform.position = Vector3.MoveTowards(transform.position, Waypoint[0].position, Crab.speed * Time.deltaTime);
            }
        }

        if (Waypoint.Length > 1)
        {
            anim.SetBool("Walk", true);
            transform.LookAt(Waypoint[WPoint_No].position);
            transform.position = Vector3.MoveTowards(transform.position, Waypoint[WPoint_No].position, Crab.speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, Waypoint[WPoint_No].position) <= 0.1f)
            {
                WPoint_No++;
                if (WPoint_No == Waypoint.Length)
                {
                    WPoint_No = 0;
                }
            }
        }
    }
}
