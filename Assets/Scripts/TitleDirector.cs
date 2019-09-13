using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject ManualMenu;
    [SerializeField] private GameObject ManualSetButton;
    [SerializeField] private GameObject ManualCloseButton;
    [SerializeField] private EventSystem MyEventSystem;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        ManualMenu.SetActive(false);
    }

    public void ManualSetOn()
    {
        MainMenu.SetActive(false);
        ManualMenu.SetActive(true);
        MyEventSystem.SetSelectedGameObject(ManualCloseButton);
    }

    public void ManualSetOff()
    {
        MainMenu.SetActive(true);
        ManualMenu.SetActive(false);
        MyEventSystem.SetSelectedGameObject(ManualSetButton);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayerSelect");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
