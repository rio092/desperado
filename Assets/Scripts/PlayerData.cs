using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    None,
    Charactor1,
    Charactor2,
    Charactor3,
    Charactor4,
}

public class PlayerData : Singleton<PlayerData>
{
    private const int maxPlayerNum = 4;
    public int MaxPlayerNum
    {
        get
        {
            return maxPlayerNum;
        }
    }

    public int participantsNum()
    {
        int num = 0;
        foreach(PlayerType type in PlayerTypes)
        {
            if (type != PlayerType.None) num++;
        }
        return num;
    }
    public PlayerType[] PlayerTypes { get; set; }

    private void PlayerTypesInit()
    {
        PlayerTypes = new PlayerType[MaxPlayerNum];
        for(int i = 0; i< PlayerTypes.Length; i++)
        {
            PlayerTypes[i] = PlayerType.None;
        }
    }
    public int[] PlayerScore { get; set; }

    private void PlayerScoreInit()
    {
        PlayerScore = new int[MaxPlayerNum];
        for(int i = 0; i < PlayerScore.Length; i++)
        {
            PlayerScore[i] = 0;
        }
    }

    public void SingletonDataReset()
    {
        PlayerTypesInit();
        PlayerScoreInit();
    }
    private new void Awake()
    {
        base.Awake();
        PlayerTypesInit();
        PlayerScoreInit();
#if UNITY_EDITOR
        //↓for debug
        PlayerScore = new int[4] { 13, 22, 13, 2 };
        PlayerTypes = new PlayerType[4]
        {
            PlayerType.Charactor1,
            PlayerType.Charactor2,
            PlayerType.Charactor3,
            PlayerType.Charactor4,
        };
        //↑for debug
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
