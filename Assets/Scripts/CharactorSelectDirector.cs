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

    }



    public void GameStart()
    {
        if(playerdata.participantsNum() >= 2)
        {
            SceneManager.LoadScene("MainGame");
        }
    }

    public void BacktoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
