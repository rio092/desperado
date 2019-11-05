using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingAnimation : MonoBehaviour
{
    //240 75 130 175 230
    [SerializeField] private float moveSpeed;
    [SerializeField, Range(0, 3)] private int rank;
    [SerializeField] private float[] rankingVertivalDiferrence;
    private Vector2 startPosition;
    private Vector2 goalPosition;
    private float moveRatio;
    private bool MoveOn = false;
    [SerializeField] CharaRankAnimation myCharaRankAnim;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (MoveOn)
        {
            verticalMove();
        }
    }

    private void verticalMove()
    {
        moveRatio = Mathf.Clamp01(moveRatio + moveSpeed);
        if(moveRatio >= 1)
        {
            MoveOn = false;
            myCharaRankAnim.MyRank = rank;
            myCharaRankAnim.RankingAnimationOn();
            return;
        }
        Vector2 moveValue = Vector2.Lerp(startPosition, goalPosition, moveRatio);
        transform.position = moveValue;
    }

    public void InfomationInit(int myRank)
    {
        startPosition = transform.position;
        rank = myRank;
        moveRatio = 0;
        if(rank != -1)
        {
            float verticalValiation = rankingVertivalDiferrence[rank-1];
            float goalPositionY = startPosition.y + verticalValiation;
            goalPosition = new Vector2(startPosition.x, goalPositionY);
        }
    }

    public void moveSwitchOn()
    {
        if(rank != -1)
        {
            MoveOn = true;

        }
    }
}
