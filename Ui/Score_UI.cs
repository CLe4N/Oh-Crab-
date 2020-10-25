using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_UI : MonoBehaviour
{
    [SerializeField] int MaxScore;
    public string Thai_txt;
    public string Eng_txt;
    public Player_health Player_stat;
    public Sub_Ui Sub_Stat;
    public bool readyToWin;
    [SerializeField] bool NotScore;
    [SerializeField] bool IsCountdown;
    Text score_text;
    void Start()
    {
        score_text = GetComponent<Text>();    
    }
    void Update()
    {
        if (NotScore == false)
        {
            if (Player_stat.player_score < MaxScore)
            {
                score_text.text = Player_stat.player_score.ToString() + " / " + MaxScore;
                readyToWin = false;
            }
            if (Player_stat.player_score >= MaxScore)
            {
                readyToWin = true;
                if (Sub_Stat.eng == true)
                {
                    score_text.text = Eng_txt;
                }
                if (Sub_Stat.eng == false)
                {
                    score_text.text = Thai_txt;
                }
            }
        }
        else
        {
            if (Sub_Stat.eng == true)
            {
                score_text.text = Eng_txt;
            }
            if (Sub_Stat.eng == false)
            {
                score_text.text = Thai_txt;
            }
        }
    }
}
