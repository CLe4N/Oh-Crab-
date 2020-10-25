using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorSet_con : MonoBehaviour
{
    public Transform player;
    public MarkerSquare markerDetect;
    public GameObject spawner1;
    public GameObject spawner2;
    [SerializeField]float speed;
    public GameObject SharkPrefab;
    public bool HasCreate;
    public AudioSource SharkRoar_sfx;
    public AudioSource SharkAttack_sfx;
    void Update()
    {
        if (markerDetect.ReadyToAttack == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, 0, 0), speed);
        }
        else
        {
            if(spawner1.activeSelf == true && spawner2.activeSelf == false)
            {
                if (HasCreate == false)
                {
                    SharkRoar_sfx.Play();
                    Instantiate(SharkPrefab, spawner1.transform.position, Quaternion.Euler(0, 0, 0), this.gameObject.transform);
                    HasCreate = true;
                    Invoke("PlayCharging_sfx", 2.0f);
                }

            }
            if (spawner1.activeSelf == false && spawner2.activeSelf == true)
            {
                if (HasCreate == false)
                {
                    SharkRoar_sfx.Play();
                    Instantiate(SharkPrefab, spawner2.transform.position, Quaternion.Euler(0, 180, 0), this.gameObject.transform);
                    HasCreate = true;
                    Invoke("PlayCharging_sfx", 2.0f);
                }
            }
        }
    }

    void PlayCharging_sfx()
    {
        SharkAttack_sfx.Play();
    }
}
