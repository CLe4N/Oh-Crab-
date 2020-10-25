using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid_Con : MonoBehaviour
{
    Rigidbody rb;
    public float Squid_speed;
    public Squid_Target Player_Target;
    Animator anim;
    public bool Squid_death;
    public int Squid_Hp;
    public Collider[] squid_collider;
    HP_income Hurt_Dmg;
    public Collider body_colider;
    float Default_Speed;

    public AudioSource Squid_Death_sound;
    public Material default_mat;
    public Material hurt_material;
    SkinnedMeshRenderer this_mat;

    Vector3 origin_rotate;
    void Start()
    {
        origin_rotate = transform.eulerAngles;
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        this_mat = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    void Update()
    {
        if (Squid_Hp <= 0)
        {
            Squid_death = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (Squid_death != true)
        {
            if (other.tag == "Player_Hitbox")
            {
                Hurt_Dmg = other.gameObject.GetComponent<HP_income>();
                Squid_Hp = Squid_Hp - Hurt_Dmg.HP_cal_Point;
                this_mat.material = hurt_material;
                Squid_Death_sound.Play();
                Invoke("normal_mat", 0.1f);
            }
            else if(other.tag == "GameOver")
            {
                Squid_Hp = 0;
            }
        }

        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }

    }

    public void Squid_move()
    {
        //rb.AddRelativeForce(Vector3.forward * Squid_speed, ForceMode.Force);
        rb.velocity = transform.forward * Squid_speed;
        anim.SetBool("Walk", true);
    }

    public void Look_Target()
    {
        transform.LookAt(Player_Target.player);
    }

    public void Squid_stop_move()
    {
        anim.SetBool("Walk", false);
        rb.velocity = Vector3.zero;
    }

    public void Squid_stop_attack()
    {
        anim.SetBool("Attack", false);
    }

    public void Squid_Attack()
    {
        Squid_stop_move();
        anim.SetBool("Attack", true);
    }

    public void origin_Squid()
    {
        transform.eulerAngles = origin_rotate;;
        rb.velocity = Vector3.zero;
        anim.SetBool("Attack", false);
        anim.SetBool("Walk", false);
    }

    public void Dying_squid()
    {
        anim.SetBool("Death", true);
        for (int i = 0; i < squid_collider.Length; i++)
        {
            squid_collider[i].enabled = false;
        }
        body_colider.isTrigger = true;
        Squid_stop_attack();
        Invoke("DestroyThis", 3.0f);
    }

    void DestroyThis()
    {
        Destroy(this.gameObject);
    }
    void normal_mat()
    {
        this_mat.material = default_mat;
    }
}
