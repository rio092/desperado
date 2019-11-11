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
    float serect=1;
    public Image restart;
    public Image title;
    float count=1.5f/255.0f;
    void Start()
    {
        controllerName = "Gamepad" + playerID + "_";
        pausemenu.SetActive(false);
        Time.timeScale = 1;
    }
    //controllerName + "Function0"
    void Update()
    {

       // Debug.Log((int)Time.realtimeSinceStartup);
        /*    if (Input.GetButtonDown("Start") ||Input.GetKeyDown("q"))
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
                if (Input.GetButtonDown("Option") || Input.GetKeyDown("e"))
                {
                    SceneManager.LoadScene("Title");
                }
            }*/
        if (is_pause)
        {
            float x = Mathf.Round(Input.GetAxis("Horizontal"));
            if (x != 0) {  serect = x; }
            if (serect == -1)
            {
                restart.color =new Color(255,255,255, 1.0f);
                if (title.color.a <= 255.0f / 255.0f && title.color.a >= 200.0f / 255.0f)
                {
                    title.color -= new Color(0, 0, 0, count);
                }else{
                    count *= (-1);
                    title.color -= new Color(0, 0, 0,5* count);
                }
                if (Input.GetButtonDown("Start") || Input.GetKeyDown("e"))
                {
                    SceneManager.LoadScene("Title");
                }
            }
            if (serect == 1)
            {
                title.color = new Color(255, 255, 255, 1.0f);
                if (restart.color.a <= 255.0f / 255.0f && restart.color.a >= 200.0f / 255.0f)
                {
                    restart.color -= new Color(0, 0, 0, count);
                }
                else
                {
                    count *= (-1);
                    restart.color -= new Color(0, 0, 0, 5 * count);
                }
                if (Input.GetButtonDown("Start") || Input.GetKeyDown("e"))
                {
                        Time.timeScale = 1;
                    pausemenu.SetActive(false);
                    is_pause = false;
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Start") || Input.GetKeyDown("q"))
            {
                Time.timeScale = 0;
                is_pause = true;
                pausemenu.SetActive(true);
            }
        }
    }
}
