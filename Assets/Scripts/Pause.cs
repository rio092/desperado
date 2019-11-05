using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool is_pause = false;
    private int hit;
    [SerializeField, Range(1, 4)] private int playerID;
    private string controllerName;
    private string controller;
    public GameObject pausemenu;
    public int n = 2;
    void Start()
    {
        controllerName = "Gamepad" + playerID + "_";
        pausemenu.SetActive(false);
    }
    //controllerName + "Function0"
    void Update()
    {
        if (Input.GetButtonDown(controllerName + "Function0") ||Input.GetKeyDown("q"))
        {

                if (is_pause)
                {
                    Time.timeScale = 1;
                    pausemenu.SetActive(false);
                    is_pause = false;
                }
                else
                {
                    Time.timeScale = 0;
                    is_pause = true;
                    pausemenu.SetActive(true);
                }
            
        }
        if (is_pause)
        {
            if (Input.GetButtonDown(controllerName + "Function2") || Input.GetKeyDown("e"))
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
