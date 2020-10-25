using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerMarker : MonoBehaviour
{
    public bool ReadyToAttack;
    public bool DetectPlayer;
    public Transform Player;
    float cooldown;
    public SpriteRenderer markerAlpha;
    public Player_health playerStat;
    public GameObject marker;
    public VerSharkDetecter detectStat;
    public VerShark_Con con;
    public AudioSource SharkRoar_sfx;
    [SerializeField] float speed;

    void Start()
    {
        markerAlpha = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStat.death_state == false)
        {
            if (detectStat.PlayerDetect == true)
            {
                if (ReadyToAttack == false)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, transform.position.y, Player.position.z), speed);
                    playerIsDetect();
                    if (DetectPlayer == true)
                    {
                        if (cooldown > 0)
                        {
                            cooldown = cooldown - Time.deltaTime;
                            markerAlpha.color = markerAlpha.color + new Color(0, 0, 0, 0.33f * Time.deltaTime);
                        }
                        else
                        {
                            SharkRoar_sfx.Play();
                            ReadyToAttack = true;
                            con.cooldown = 1.0f;
                        }
                    }
                }
            }
            else
            {
                con.cooldown = 0f;
                DetectPlayer = false;
            }
        }
        else
        {
            marker.SetActive(false);
        }
    }

    void playerIsDetect()
    {
        if ((Player.position.x - transform.position.x) < 0.1 && (Player.position.x - transform.position.x) > -0.1)
        {
            if (DetectPlayer != true)
            {
                cooldown = 3.0f;
                DetectPlayer = true;
            }
        }
    }
}
