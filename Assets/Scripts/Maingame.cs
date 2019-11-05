using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Maingame : MonoBehaviour
{
    public Text START; 
    public GameObject start;
    public GameObject[] player = new GameObject[4];
    public PlayerData playerdata;
    public Stage stage;
    public Movement movement;
   private int livingplayer;
    private int set = 1;
    public int maxset;
    int DeathCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        while(4 > i)
        {
            if (PlayerData.Instance.PlayerTypes[i] != PlayerType.None)
            {
                Instantiate(player[i]);
            }
        i++;
        }
        StartCoroutine("TimeStart");
    }

    // Update is called once per frame
    IEnumerator TimeStart()
    {
        START.text = "3";
        yield return new WaitForSeconds(1);
        START.text = "2";
        yield return new WaitForSeconds(1);
        START.text = "1";
        yield return new WaitForSeconds(1);
        START.text = "START";
        yield return new WaitForSeconds(1);
        start.SetActive(false);
    }
    public void GameSet()
    {
        DeathCount++;
        Debug.Log(DeathCount);
        if (DeathCount >= playerdata.participantsNum() - 1)
        {
            StartCoroutine("End");   
        }
    }
    IEnumerator End() {
        yield return new WaitForSeconds(1);
        if (set < maxset)
        {
            SceneManager.LoadScene("MainGame");
        }
        else
        {
            SceneManager.LoadScene("Result");
        }
    }
}
