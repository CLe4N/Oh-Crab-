using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GrndEnemy_Con : MonoBehaviour
{
    Rigidbody rb;
    HP_income player_damage;
    public Collider[] enemy_col;
    [SerializeField] int hp;
    public AudioSource hurt_sound;
    SkinnedMeshRenderer this_mat;
    public Material default_mat;
    public Material hurt_mat;
    public bool dying;
    public float rot_speed;
    public float speed;
    Animator anim;

    public Vector3 origin_rotate;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        this_mat = GetComponentInChildren<SkinnedMeshRenderer>();
        origin_rotate = transform.rotation.eulerAngles;
    }
    void Update()
    {
        if(hp <= 0)
        {
            dying = true;
            speed = 0;
            rot_speed = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player_Hitbox")
        {
            hurt_sound.Play();
            player_damage = other.gameObject.GetComponent<HP_income>();
            hp = hp - player_damage.HP_cal_Point;
            this_mat.material = hurt_mat;
            Invoke("normal_mat", 0.1f);
        }
        if(other.tag == "GameOver")
        {
            hp = 0;
            this_mat.material = hurt_mat;
            Invoke("normal_mat", 0.1f);
        }
    }
    public void move()
    {
        rb.velocity = transform.forward * speed;
        anim.SetBool("Walk", true);
        stop_Attack();
    }
    public void stop_move()
    {
        rb.velocity = Vector3.zero;
        anim.SetBool("Walk", false);
    }

    public void Attack()
    {
        stop_move();
        anim.SetBool("Attack",true);
    }
    
    public void stop_Attack()
    {
        anim.SetBool("Attack", false);
    }

    public void origin_stage()
    {
        transform.eulerAngles = origin_rotate;
        rb.velocity = Vector3.zero;
        anim.SetBool("Attack", false);
        anim.SetBool("Walk", false);
    }
    public void Crab_Death()
    {
        anim.SetBool("Death", true);
        rb.velocity = Vector3.zero;

        for(int i = 0; i < enemy_col.Length;i++)
        {
            enemy_col[i].enabled = false;
        }
    }
    void normal_mat()
    {
        this_mat.material = default_mat;
    }
}
