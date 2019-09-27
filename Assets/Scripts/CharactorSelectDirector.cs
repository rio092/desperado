using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharactorSelectDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        if(PlayerData.Instance.participantsNum() >= 2)
        {
            SceneManager.LoadScene("MainGame");
        }
    }

    public void BacktoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
