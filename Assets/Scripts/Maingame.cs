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
  //  public PlayerData playerdata;
    public Stage stage;
    public Stageout stageout;
    public int winner;
    int DeathCount = 0;
    private Image candy;
    [SerializeField]
    private Sprite[] sprite;
    public int maxset;

    // Start is called before the first frame update
    void Start()
    {
     //   MakeScore();
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
        AudioManager.Instance.PlayBGM(BGMName.main);
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
        winner = stage.winner - Stageout.winner;
     //   Debug.Log(winner + "winner");
        DeathCount++;
      //  Debug.Log(DeathCount);
        if (winner >= 0)
        {
            
            if (DeathCount >= PlayerData.Instance.participantsNum() - 1)
            {
                PlayerData.Instance.PlayerScore[winner]+=Stageout.score+1;
                //       candy = GameObject.Find("candy" + (winner * 2)).GetComponent<Image>();
                //           candy.sprite = sprite[winner];

                StartCoroutine("End");
            }
        }
    }
    IEnumerator End() { 
        player[winner].GetComponent<Rigidbody2D>().velocity =new Vector2 (0, 0);
        if (winner >= 0)
        {PlayerData.Instance.set += 1;
            if (PlayerData.Instance.set < maxset)
            {
                yield return new WaitForSeconds(1);
                AudioManager.Instance.StopAllsound();
                SceneManager.LoadScene("MainGame");
            }
            else
            {
               // PlayerData.Instance.set = 0;
                   yield return new WaitForSeconds(1);
                AudioManager.Instance.StopAllsound();
                SceneManager.LoadScene("Result");
            }
        }
        else {
            yield return new WaitForSeconds(1);
     //       AudioManager.Instance.StopAllsound();
            SceneManager.LoadScene("MainGame");
        }
    }
    void MakeScore() {
        for (int i = 0; i < 4; i++)
        { 
            candy = GameObject.Find("candy" + (i*2)).GetComponent<Image>();
            if(PlayerData.Instance.PlayerScore[i] == 1)
            candy.sprite = sprite[i];
       }
    }
}
