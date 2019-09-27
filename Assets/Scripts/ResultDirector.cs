using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDirector : MonoBehaviour
{
    private int[] PlayerRank;
    private int[] PlayerRankCalculate(int[] PlayerScoreData)
    {
        int[] rank = new int[PlayerData.Instance.MaxPlayerNum];
        int[] playerRank = new int[rank.Length];
        for (int i = 0; i < rank.Length; i++)
        {
            if (PlayerData.Instance.PlayerTypes[i] == PlayerType.None)
                PlayerScoreData[i] = int.MinValue;
            rank[i] = i;
        }
        for (int i = rank.Length - 1; i > 0; i--)
        {
            for (int k = 0; k < i; k++)
            {
                if (PlayerScoreData[rank[k]] < PlayerScoreData[rank[k + 1]])
                {
                    int tmp = rank[k];
                    rank[k] = rank[k + 1];
                    rank[k + 1] = tmp;
                }
            }
        }
        for(int i = 0;i < rank.Length; i++)
        {
            if(PlayerData.Instance.PlayerTypes[rank[i]] != PlayerType.None)
            {
                playerRank[rank[i]] = i + 1;
                if(i != 0)
                {
                    if(PlayerScoreData[rank[i]] == PlayerScoreData[rank[i - 1]])
                    {
                        playerRank[rank[i]] = playerRank[rank[i - 1]];
                    }
                }
            }
            else
            {
                playerRank[rank[i]] = -1;
            }
        }
        return playerRank;
    }

    [SerializeField] private Sprite[] rankImages;
    [SerializeField] private Image[] playerRankImage;
    private void MakeRankingDisplay(int[] playerRank)
    {
        for(int i = 0;i < playerRankImage.Length; i++)
        {
            if(playerRank[i] != -1)
            {
                playerRankImage[i].sprite = rankImages[playerRank[i]];
            }
            else
            {
                playerRankImage[i].sprite = rankImages[0];
            }
        }
    }
    private void debuglogarray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Debug.Log((i + 1) + "P = " + array[i] + "位");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerRank = PlayerRankCalculate(PlayerData.Instance.PlayerScore);
        //debuglogarray(PlayerRank);
        MakeRankingDisplay(PlayerRank);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
