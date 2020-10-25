using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Score_UI winStat;
    public Transform goalPos;
    public GameObject Arrow;
    [SerializeField] float rot_speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (winStat != null)
        {
            var rotation = Quaternion.LookRotation(goalPos.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rot_speed);
            if (winStat.readyToWin == true)
            {
                Arrow.SetActive(true);
            }
        }
        else
        {
            var rotation = Quaternion.LookRotation(goalPos.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rot_speed);
            Arrow.SetActive(true);
        }
    }
}
