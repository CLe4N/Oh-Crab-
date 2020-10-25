using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class TextMesh_con : MonoBehaviour
{
    public string Eng_Text;
    public string Thai_Text;
    public Sub_Ui Text_stat;
    public Ability_Ui ability_bt;
    public Transform PlayerDis;

    [SerializeField] float CheckDis;
    TextMesh OverHead_txt;
    void Start()
    {
        OverHead_txt = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,Camera.main.transform.rotation * Vector3.up);
        if (PlayerDis == null)
        {
            if (ability_bt == null)
            {
                if (Text_stat.eng == true)
                {
                    OverHead_txt.text = Eng_Text;
                }
                if (Text_stat.eng == false)
                {
                    OverHead_txt.text = Thai_Text;
                }
            }
            else
            {
                if (ability_bt.abilityIsTouch == true)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    if (Text_stat.eng == true)
                    {
                        OverHead_txt.text = Eng_Text;
                    }
                    if (Text_stat.eng == false)
                    {
                        OverHead_txt.text = Thai_Text;
                    }
                }
            }
        }
        else
        {
            if (ability_bt == null)
            {
                if (Text_stat.eng == true)
                {
                    OverHead_txt.text = Eng_Text;
                }
                if (Text_stat.eng == false)
                {
                    OverHead_txt.text = Thai_Text;
                }
            }
            else
            {
                if (ability_bt.abilityIsTouch == true)
                {
                    if (Vector3.Distance(transform.position, PlayerDis.position) < CheckDis)
                    {
                        Destroy(this.gameObject);
                    }
                }
                else
                {
                    if (Text_stat.eng == true)
                    {
                        OverHead_txt.text = Eng_Text;
                    }
                    if (Text_stat.eng == false)
                    {
                        OverHead_txt.text = Thai_Text;
                    }
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, CheckDis);
    }

}
