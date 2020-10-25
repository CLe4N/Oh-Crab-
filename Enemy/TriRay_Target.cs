using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TriRay_Target : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float side_distance;
    [SerializeField] float height_Multiplier;
    [SerializeField] float Angle;

    [SerializeField] float closeDis;
    [SerializeField] float longDis;

    Rigidbody rb;
    Animator anim;

    float PlayerDis = Mathf.Infinity;
    bool PlayerIsDetect;

    public Transform player;
    
    public WayP_move Enemy_WayP;
    public Hide Hide_Stat;
    public GrndEnemy_Con con;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (con.dying == false)
        {
            if (Hide_Stat == null)
            {
                Vision_detect();
                DisCheck();
            }
            else
            {
                if (Hide_Stat.Hidding == false)
                {
                    Vision_detect();
                    DisCheck();
                }
                else
                {
                    PlayerIsDetect = false;
                    Enemy_WayP.Waypoint_move();
                }
            }
        }
        else
        {
            con.Crab_Death();
            Invoke("Destroy_this", 3.0f);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, closeDis);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, longDis);
    }

    void Vision_detect()
    {
        RaycastHit front_hit, right_hit, left_hit;
        Debug.DrawRay((transform.position + transform.forward) + Vector3.up * height_Multiplier, transform.forward * distance, Color.red);

        Debug.DrawRay((transform.position + transform.forward) + Vector3.up * height_Multiplier, 
            (transform.forward + (transform.right * Angle)).normalized * side_distance, Color.red);

        Debug.DrawRay((transform.position + transform.forward) + Vector3.up * height_Multiplier, 
            (transform.forward - (transform.right * Angle)).normalized * side_distance, Color.red);

        if (Physics.Raycast((transform.position + transform.forward) + Vector3.up * height_Multiplier, transform.forward, out front_hit, distance))
        {
            if (front_hit.collider.gameObject.tag == "Player")
            {
                move_forward();
                if (PlayerDis <= closeDis)
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, 0);
                    anim.SetBool("Attack", true);
                }
                else
                {
                    anim.SetBool("Attack", false);
                }
            }
        }

        if (Physics.Raycast((transform.position + transform.forward) + Vector3.up * height_Multiplier,
            (transform.forward + (transform.right * Angle)).normalized, out right_hit, side_distance))
        {
            if (right_hit.collider.gameObject.tag == "Player")
            {
                PlayerIsDetect = true;
            }
        }

        if (Physics.Raycast((transform.position + transform.forward) + Vector3.up * height_Multiplier,
            (transform.forward - (transform.right * Angle)).normalized, out left_hit, side_distance))
        {
            if (left_hit.collider.gameObject.tag == "Player")
            {
                PlayerIsDetect = true;
            }
        }
    }

    void DisCheck()
    {
        PlayerDis = Vector3.Distance(player.position, transform.position);
        if (PlayerDis <= longDis)
        {
            if (PlayerIsDetect == true)
            {
                    var rotation = Quaternion.LookRotation(player.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * con.rot_speed);
            }
            else
            {
                Enemy_WayP.Waypoint_move();
            }
        }
        else
        {
            PlayerIsDetect = false;
            Enemy_WayP.Waypoint_move();
        }
    }

    void move_forward()
    {
        rb.velocity = transform.forward * con.speed;
        anim.SetBool("Walk", true);
    }

    void stop_move()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        anim.SetBool("Walk", false);
    }
    void Destroy_this()
    {
        Destroy(this.gameObject);
    }
}
