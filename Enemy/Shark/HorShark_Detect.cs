using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorShark_Detect : MonoBehaviour
{
    [SerializeField] bool IsTurnActivate;
    public GameObject HorShark_set;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (IsTurnActivate == true)
            {
                HorShark_set.SetActive(true);
            }
            else
            {
                HorShark_set.SetActive(false);
            }
        }
    }
}
