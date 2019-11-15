using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Stageout : MonoBehaviour
{
    public Maingame maingame;
    public Stage stage;
    public static int winner = 0;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        winner = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySE(SEName.Fall, (float)0.3);
            string winnernum = Regex.Replace(col.gameObject.name, @"[^0-9]", "");
            int death = int.Parse(winnernum);
            winner += death;
            score++;
            if (score <= PlayerData.Instance.participantsNum()-1)
            {
                PlayerData.Instance.PlayerScore[death - 1] += score;
            //    Debug.Log(PlayerData.Instance.PlayerScore[death - 1]+"PLAYER"+death);
            }
            maingame.GameSet();
        }
    }

}
