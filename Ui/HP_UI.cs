using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_UI : MonoBehaviour
{
    public Player_health Hp;
    int heart_num;

    public GameObject heart1,heart2,heart3;
    void Start()
    {
        
    }

    void Update()
    {
        heart_num = Hp.player_hp / 10;

        if(heart_num > 0 && heart_num < 2)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
        }

        else if (heart_num > 1 && heart_num < 3)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(false);
        }

        else if (heart_num >= 3)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
        }

        else
        {
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
        }
    }
}
