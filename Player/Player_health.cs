using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour
{
    public int player_hp;
    public int player_score;
    public Goal_Point WinStat;
    public AudioSource player_Hurt_SFX;
    public AudioSource BGM_song;
    public AudioSource PlayerGetItem_SFX;
    public AudioSource PlayerHeal_SFX;
    public Collider[] player_col;
    Animator anim;
    public SkinnedMeshRenderer this_mat;
    public Material default_mat;
    public Material heal_mat;
    public Material hurt_mat;
    public bool death_state;
    public Hide IsHide;
    HP_income Income_Point;
    float HurtCoolDown;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    void Update()
    {
        if(player_hp <= 0)
        {
            death_state = true;
            collider_off();
            BGM_song.Stop();
            anim.SetBool("Death", true);
        }
        if(player_hp > 30)
        {
            player_hp = 30;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(WinStat == null)
        {
            if (other.tag == "Enemy")
            {
                Income_Point = other.gameObject.GetComponent<HP_income>();
                player_hp -= Income_Point.HP_cal_Point;
                player_Hurt_SFX.Play();
                this_mat.material = hurt_mat;
                Invoke("normal_mat", 0.1f);

            }

            if(other.tag == "Puffer_Hitbox")
            {
                if (IsHide.Hidding == false)
                {
                    Income_Point = other.gameObject.GetComponent<HP_income>();
                    player_hp -= Income_Point.HP_cal_Point;
                    player_Hurt_SFX.Play();
                    this_mat.material = hurt_mat;
                    Invoke("normal_mat", 0.1f);
                }
            }

            if (other.tag == "Item")
            {
                Income_Point = other.gameObject.GetComponent<HP_income>();
                player_hp += Income_Point.HP_cal_Point;
                player_score += Income_Point.Score_Point;
                PlayerGetItem_SFX.Play();
                if (Income_Point.HP_cal_Point > 0)
                {
                    this_mat.material = heal_mat;
                    PlayerHeal_SFX.Play();
                    Invoke("normal_mat", 0.1f);
                }
                Destroy(other.gameObject);
            }

            if (other.tag == "GameOver")
            {
                player_hp = 0;
                player_Hurt_SFX.Play();
                this_mat.material = hurt_mat;
                Invoke("normal_mat", 0.1f);
            }
        }
        else
        {
            if (WinStat.PlayerIsWin == false)
            {
                if (other.tag == "Enemy")
                {
                    Income_Point = other.gameObject.GetComponent<HP_income>();
                    player_hp -= Income_Point.HP_cal_Point;
                    player_Hurt_SFX.Play();
                    this_mat.material = hurt_mat;
                    Invoke("normal_mat", 0.1f);
                }
                if (other.tag == "Item")
                {
                    Income_Point = other.gameObject.GetComponent<HP_income>();
                    player_hp += Income_Point.HP_cal_Point;
                    player_score += Income_Point.Score_Point;
                    PlayerGetItem_SFX.Play();
                    if (Income_Point.HP_cal_Point > 0)
                    {
                        this_mat.material = heal_mat;
                        PlayerHeal_SFX.Play();
                        Invoke("normal_mat", 0.1f);
                    }
                    Destroy(other.gameObject);
                }

                if (other.tag == "GameOver")
                {
                    player_hp = 0;
                    player_Hurt_SFX.Play();
                    this_mat.material = hurt_mat;
                    Invoke("normal_mat", 0.1f);
                }
            }
        }
    }


    void collider_off()
    {
        for (int i = 0; i < player_col.Length;)
        {
            player_col[i].enabled = false;
            i++;
        }
    }

    void normal_mat()
    {
        this_mat.material = default_mat;
    }
}
