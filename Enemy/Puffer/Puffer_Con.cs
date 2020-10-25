using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puffer_Con : MonoBehaviour
{
    public Puffer_Event puffEvent;
    public Transform player;
    public GameObject marker;
    public bool PlayerDetect;
    [SerializeField] float speed;
    [SerializeField] float rot_speed;
    public Player_health playerStat;
    Rigidbody rb;
    Animator anim;
    public float BackWardTime;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (puffEvent.IsBackward == true)
        {
            if (BackWardTime > 0)
            {
                var rotation = Quaternion.LookRotation(player.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rot_speed);
                rb.velocity = transform.forward * -speed;
                BackWardTime -= Time.deltaTime;
            }
            else
            {
                stopBackward();
            }
            
        }
        else
        {
            if(playerStat.death_state == false)
            markerCheck();
            Puffer_con();
        }
    }

    void markerCheck()
    {
        if(Vector3.Distance(marker.transform.position,player.position) < 1.2f)
        {
           PlayerDetect = true;
        }
    }

    void Puffer_con()
    {
        if (PlayerDetect == false)
        {
            var rotation = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rot_speed);
            rb.velocity = transform.forward * speed;
            anim.SetBool("Walk", true);
        }
        else
        {
            if (marker.activeSelf == true)
            {
                rb.velocity = Vector3.zero;
                anim.SetBool("Walk", false);
                Invoke("Attack", 0.25f);
            }
        }
    }

    void Attack()
    {
        anim.SetBool("Attack", true);

    }

    public void StopAttack()
    {
        anim.SetBool("Attack", false);
    }

    public void HurtAnim()
    {
        anim.SetBool("Hurt", true);
    }  
    public void StopHurtAnim()
    {
        anim.SetBool("Hurt", false);
    }

    void stopBackward()
    {
        puffEvent.IsBackward = false;
        marker.SetActive(true);
    }
    public void IsKinetic()
    {
        rb.isKinematic = true;
    }
    public void IsNotKinetic()
    {
        rb.isKinematic = false;
    }
}
