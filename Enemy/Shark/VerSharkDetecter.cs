using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerSharkDetecter : MonoBehaviour
{
    public bool PlayerDetect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if(other.tag =="Player")
        {
            PlayerDetect = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerDetect = false;
        }
    }
}
