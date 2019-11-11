using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Stageout : MonoBehaviour
{
    public Maingame maingame;
    public Stage stage;
    public int winner = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
     /*       string winnernum = Regex.Replace(col.gameObject.name, @"[^0-9]", "");
            int death = int.Parse(winnernum);
            winner += death;
            */
            Destroy(col.gameObject);
          //  maingame.GameSet();
        }
    }

}
