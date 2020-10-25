using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerShark_Con : MonoBehaviour
{
    public VerMarker markerStat;
    public Transform marker;
    public Transform StartPoint;
    public AudioSource SharkImpact_sfx;
    bool IsGround;
    public float cooldown;
    [SerializeField] float speed;


    void Update()
    {
        if (IsGround == false)
        {
            if (markerStat.ReadyToAttack == true)
            {
                if (cooldown > 0)
                {
                    cooldown = cooldown - Time.deltaTime;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(marker.position.x, marker.position.y, marker.position.z), speed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, marker.position) <= 0)
                    {
                        markerStat.markerAlpha.color = new Color(1, 1, 1, 0);
                        IsGround = true;
                        SharkImpact_sfx.Play();
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(marker.position.x, transform.position.y, marker.position.z), speed);
            }
        }
        if(IsGround == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(StartPoint.position.x, StartPoint.position.y, StartPoint.position.z), speed * Time.deltaTime);
            if(Vector3.Distance(transform.position, StartPoint.position)<=0)
            {
                markerStat.ReadyToAttack = false;
                markerStat.DetectPlayer = false;
                IsGround = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
    }

    void SharkAttack()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(marker.position.x, marker.position.y, marker.position.z), speed * Time.deltaTime);
    }
}
