using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBorder : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
