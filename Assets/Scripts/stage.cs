using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Stage : MonoBehaviour
{
    public int score = 0;
    public Maingame maingame;
    public int winner  ;
    // Start is called before the first frame update
    void Start()
    {   int i = 0;
        while (4 > i)
        {
            if (PlayerData.Instance.PlayerTypes[i] != PlayerType.None)
            {
                winner += i+1;
            }
            i++;
        }
        winner --;
        Debug.Log(winner+"aaaaaaaaaaaaaaaaaa");
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        
    /*    if (col.gameObject.tag == "Player")
        {
            string winnernum = Regex.Replace(col.gameObject.name, @"[^0-9]", "");
            int death = int.Parse(winnernum);
            winner -= death;
            score++;
            if (score < 4)
            {
                PlayerData.Instance.PlayerScore[death - 1] += score;
                Debug.Log("kierokasu" + death);
                Debug.Log("jamaaaaa" + PlayerData.Instance.PlayerScore[death - 1]);
            }
       //     Destroy(col.gameObject);
            maingame.GameSet();
        }*/
    }
    
}