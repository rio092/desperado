using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Stage : MonoBehaviour
{
    private int score = 0;
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
        Debug.Log(winner);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            string winnernum = Regex.Replace(col.gameObject.name, @"[^0-9]", "");
            int death = int.Parse(winnernum);
            winner -= death;
           
            Destroy(col.gameObject);
            maingame.GameSet();
        }
    }
    
}


