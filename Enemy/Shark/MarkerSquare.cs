using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class MarkerSquare : MonoBehaviour
{
    public bool ReadyToAttack;
    public bool DetectPlayer;
    public Transform Player;
    float cooldown;
    public SpriteRenderer markerAlpha;
    public Player_health playerStat;
    public GameObject marker;
    void Start()
    {
        markerAlpha = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerStat.death_state == false)
        {
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
                    ReadyToAttack = true;
                }
            }
        }
        else
        {
            marker.SetActive(false);
        }
    }

    void playerIsDetect()
    {
        if ((Player.position.x-transform.position.x) < 1 && (Player.position.x - transform.position.x) > -1)
        {
            if (DetectPlayer != true)
            {
                cooldown = 3.0f;
                DetectPlayer = true;
            }
        }
    }
}
