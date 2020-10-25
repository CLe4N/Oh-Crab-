using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_con : MonoBehaviour
{
    public Transform Player;
    public float smooth;
    public Vector3 OffSet_Pos;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 TargetPos = new Vector3(Player.position.x + OffSet_Pos.x, Player.position.y + OffSet_Pos.y, Player.position.z + OffSet_Pos.z);//use X =  79.36
        Vector3 SmoothPos = Vector3.Lerp(transform.position, TargetPos, smooth);
        transform.position = SmoothPos;
    }
}
