using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharactorSelectDirector : MonoBehaviour
{
    [SerializeField] Text startText;
    private PlayerData playerdata;
    private Animator textAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerdata = PlayerData.Instance;
        textAnim = startText.GetComponent<Animator>();
        AudioManager.Instance.PlayBGM(BGMName.Title);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerdata.participantsNum() >= 2)
        {
            textAnim.SetBool("IsTextChanging", true);
        }
        else
        {
            textAnim.SetBool("IsTextChanging", false);
        }
        if (Input.GetButtonDown("Start") || Input.GetKeyDown(KeyCode.A))
        {
            GameStart();
        }
        if (Input.GetButtonDown("Option"))
        {
            playerdata.SingletonDataReset();
            BacktoTitle();
        }

    }



    public void GameStart()
    {
        if(playerdata.participantsNum() >= 2)
        {
            AudioManager.Instance.StopAllsound();
            SceneManager.LoadScene("MainGame");
        }
    }

    public void BacktoTitle()
    {
        PlayerData.Instance.SingletonDataReset();
        AudioManager.Instance.StopAllsound();
        SceneManager.LoadScene("Title");
    }
}
