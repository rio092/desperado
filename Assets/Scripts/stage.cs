using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private int score = 0;
    public int LivingPlayerNum;
    public Maingame maingame;
    // Start is called before the first frame update
    void Start()
    {
        // LivingPlayerNum = playerdata.participantsNum();
        LivingPlayerNum = 4;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            maingame.GameSet();
        }
    }
    
}


