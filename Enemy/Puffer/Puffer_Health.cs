using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Puffer_Health : MonoBehaviour
{
    public int Puffer_HP;
    public bool IsWeak;
    HP_income player_damage;
    public AudioSource Impact_sfx;
    public AudioSource Hurt_sfx;
    public GameObject marker;
    public Puffer_Event puff_event;
    public bool GotHit;
    public SkinnedMeshRenderer this_mat;
    public Material default_mat;
    public Material hurt_mat;
    public LoadScene loadNextScene;
    public ProgressBar TimeBar;

    private void Start()
    {
        default_mat.color = Color.white;
    }
    void Update()
    {
        if(TimeBar.TimeIsUp == true)
        {
            goNextScene();
        }
    }
    private void OnDisable()
    {
        default_mat.color = Color.white;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player_Hitbox")
        {
            if(IsWeak == false)
            {
                Impact_sfx.Play();
            }
            if(IsWeak == true)
            {
                player_damage = other.gameObject.GetComponent<HP_income>();
                Puffer_HP = Puffer_HP - player_damage.HP_cal_Point;
                Hurt_sfx.Play();
                GotHit = true;
                this_mat.material = hurt_mat;
                puff_event.new_cooldown = puff_event.new_cooldown - 0.5f;
                Puffer_HP = Puffer_HP - player_damage.HP_cal_Point;
                default_mat.color = default_mat.color - new Color(0.25f, 0.5f, 0.5f);
                print(default_mat.color);
                Invoke("normal_mat",0.1f);
            }
        }
    }

    void normal_mat()
    {
        this_mat.material = default_mat;
    }

    void goNextScene()
    {
        loadNextScene.loadNextScene();
    }
}
