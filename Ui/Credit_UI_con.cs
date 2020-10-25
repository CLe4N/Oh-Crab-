using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit_UI_con : MonoBehaviour
{
    public GameObject[] credit;
    public GameObject creditWindow;
    [SerializeField]int count;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        print(count);
    }

    public void openNextWindow()
    {
        if(count < credit.Length-1)
        {
            count += 1;
            credit[count].SetActive(true);
            credit[count - 1].SetActive(false);

        }            
        else
        {
            creditWindow.SetActive(false);
            credit[count].SetActive(false);
            credit[0].SetActive(true);
            count = 0;
        }
    }
}
