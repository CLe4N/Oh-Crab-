using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayP_Target : MonoBehaviour
{
    public WayP_move WP_con;
    public GrndEnemy_Con con;
    void Update()
    {
        if (con.dying != true)
        {
            WP_con.Waypoint_move();
        }
        else
        {
            con.Crab_Death();
            Invoke("Destroy_this", 3.0f);
        }
    }

    void Destroy_this()
    {
        Destroy(this.gameObject);
    }
}
