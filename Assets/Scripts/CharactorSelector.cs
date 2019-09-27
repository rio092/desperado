using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorSelector : MonoBehaviour
{
    private bool isSelected;
    private bool inputIsEnabled;
    [SerializeField, Range(1, 4)] private int playerID;
    private int maxPlayerNum;
    private string controllerName;
    private int selectedCharaType;
    [SerializeField] Image CharactorImageUI;
    [SerializeField] Sprite[] CharactorImage;
    [SerializeField] private float inputInterval;
    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        isSelected = false;
        inputIsEnabled = true;
        controllerName = "Gamepad" + playerID + "_";
        selectedCharaType = (int)PlayerType.None;
        PlayerCharactorUpdate(selectedCharaType);
        maxPlayerNum = PlayerData.Instance.MaxPlayerNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputIsEnabled)
        {
            if (!isSelected)
            {
                //input keycode is used for debug
                if (Input.GetButtonDown(controllerName + "Function0") || Input.GetKeyDown(KeyCode.M))
                {
                    isSelected = true;
                    selectedCharaType = (int)PlayerType.Charactor1;
                    PlayerCharactorUpdate(selectedCharaType);
                    inputIsEnabled = false;
                    StartCoroutine(WaitInputInterval());
                }
            }
            else
            {
                if(Input.GetButtonDown(controllerName + "Function1") || Input.GetKeyDown(KeyCode.N))
                {
                    isSelected = false;
                    selectedCharaType = (int)PlayerType.None;
                    PlayerCharactorUpdate(selectedCharaType);
                    inputIsEnabled = false;
                    StartCoroutine(WaitInputInterval());
                }
                else
                {
                    //float axis = Input.GetAxisRaw(controllerName + "Y");
                    //for debug
                    float axis = Input.GetAxisRaw("Vertical");
                    if(axis >= 1.0f)
                    {
                        selectedCharaType = (selectedCharaType % maxPlayerNum) + 1;
                        PlayerCharactorUpdate(selectedCharaType);
                        inputIsEnabled = false;
                        StartCoroutine(WaitInputInterval());
                    }
                    else if(axis <= -1.0f)
                    {
                        selectedCharaType--;
                        if (selectedCharaType <= 0) selectedCharaType = maxPlayerNum;
                        PlayerCharactorUpdate(selectedCharaType);
                        inputIsEnabled = false;
                        StartCoroutine(WaitInputInterval());
                    }
                }
            }
        }
    }

    private void PlayerCharactorUpdate(int playerType)
    {
        switch (playerType)
        {
            case (int)PlayerType.None:
                PlayerData.Instance.PlayerTypes[playerID - 1] = PlayerType.None;
                break;
            case (int)PlayerType.Charactor1:
                PlayerData.Instance.PlayerTypes[playerID - 1] = PlayerType.Charactor1;
                break;
            case (int)PlayerType.Charactor2:
                PlayerData.Instance.PlayerTypes[playerID - 1] = PlayerType.Charactor2;
                break;
            case (int)PlayerType.Charactor3:
                PlayerData.Instance.PlayerTypes[playerID - 1] = PlayerType.Charactor3;
                break;
            case (int)PlayerType.Charactor4:
                PlayerData.Instance.PlayerTypes[playerID - 1] = PlayerType.Charactor4;
                break;
        }
        CharactorImageUI.sprite = CharactorImage[playerType];
    }

    IEnumerator WaitInputInterval()
    {
        yield return new WaitForSecondsRealtime(inputInterval);
        inputIsEnabled = true;
    }
}
