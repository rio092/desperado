using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public enum animationIndex
{
    Idle1,Idle2,Idle3,
    No1Anim1,No1Anim2,No1Anim3,
    No2Anim1,No2Anim2,
    No3Anim1,No3Anim2,
    No4Anim1,No4Anim2,No4Anim3
}

public class CharaRankAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private int myPlayerID;
    private int myRank;
    public int MyRank { get => myRank; set => myRank = value; }
    [SerializeField] private animationIndex mySpriteIndex;
    private animationIndex preIndex;
    private Image playerImage;

    private Animator animator;

    private void Awake()
    {
        playerImage = GetComponent<Image>();
        animator = GetComponent<Animator>();
        LoadAnimationSprite();
    }
    // Start is called before the first frame update
    void Start()
    {
        mySpriteIndex = animationIndex.Idle1;
        preIndex = mySpriteIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(mySpriteIndex != preIndex)
        {
            playerImage.sprite = sprites[(int)mySpriteIndex];
            preIndex = mySpriteIndex;
        }
    }

    private void LoadAnimationSprite()
    {
        string assetBundlePath = Application.streamingAssetsPath + "/"+myPlayerID + "p";
        AssetBundle bundle = AssetBundle.LoadFromFile(assetBundlePath);
        sprites = new Sprite[System.Enum.GetValues(typeof(animationIndex)).Length];
        foreach (var animName in System.Enum.GetNames(typeof(animationIndex)).Select((value, index) => new { value, index }))
        {
            sprites[animName.index] = bundle.LoadAsset<Sprite>(animName.value);
        }
        /*
        sprites = new Sprite[System.Enum.GetValues(typeof(animationIndex)).Length];
        string basepath = myPlayerID + "P/リザルト/";
        foreach (var animName in System.Enum.GetNames(typeof(animationIndex)).Select((value,index) => new {value,index}))
        {
            sprites[animName.index] = (Sprite)Resources.Load(basepath + animName.value, typeof(Sprite));
        }
        */
    }

    public void RankingAnimationOn()
    {
        switch (MyRank)
        {
            case 1:
                animator.SetTrigger("IsRankingNo1");
                break;
            case 2:
                animator.SetTrigger("IsRankingNo2");
                break;
            case 3:
                animator.SetTrigger("IsRankingNo3");
                break;
            case 4:
                animator.SetTrigger("IsRankingNo4");
                break;
            default:
                break;
        }
    }
}
