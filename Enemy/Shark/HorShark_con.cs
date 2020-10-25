using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorShark_con : MonoBehaviour
{
    [SerializeField] float Speed;
    HorSet_con Horset;
    MarkerSquare marker;
    public GameObject spawner1;
    public GameObject spawner2;
    public bool spawnerStat;
    void Start()
    {
        marker = GameObject.Find("SharkHor_Set").transform.GetChild(0).GetComponent<MarkerSquare>();
        spawner1 = GameObject.Find("SharkHor_Set").transform.GetChild(1).gameObject;
        spawner2 = GameObject.Find("SharkHor_Set").transform.GetChild(2).gameObject;
        Horset = GetComponentInParent<HorSet_con>();
    }
    void Update()
    {
        if(spawner1.activeSelf == true && spawner2.activeSelf == false)
        {
            Invoke("MoveUp",2.0f);
            //transform.position = Vector3.MoveTowards(transform.position, spawner2.transform.position, Speed * Time.deltaTime);
            if (Vector3.Distance(transform.position,spawner2.transform.position)<=0)
            {
                spawner1.SetActive(false);
                spawner2.SetActive(true);
                Destroy(this.gameObject);
            }
        }
        if(spawner2.activeSelf == true && spawner1.activeSelf == false)
        {
            Invoke("moveDown",2.0f);
            //transform.position = Vector3.MoveTowards(transform.position, spawner1.transform.position, Speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, spawner1.transform.position) <= 0)
            {
                spawner1.SetActive(true);
                spawner2.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }
    void MoveUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, spawner2.transform.position, Speed * Time.deltaTime);
    }

    void moveDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, spawner1.transform.position, Speed * Time.deltaTime);
    }

    void OnDestroy()
    {
        Horset.HasCreate = false;
        marker.ReadyToAttack = false;
        marker.DetectPlayer = false;
        marker.markerAlpha.color = new Color(1,1,1,0);
    }
}