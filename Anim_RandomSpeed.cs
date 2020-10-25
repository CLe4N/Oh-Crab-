using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_RandomSpeed : MonoBehaviour
{
    Animator anim;
    void Start()
    {

        anim = GetComponent<Animator>();
        anim.speed = Random.Range(1.5f,2.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
