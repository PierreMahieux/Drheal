using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject canevas;
    public GameObject winUI;
    public GameObject EscapeUI;
    public GameObject GameOverUI;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //EscapeUI = canevas.transform.Find("EscapeUI").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowWinMenu()
    {
        winUI.SetActive(true);
    }

    public void ShowEscapeMenu()
    {
        EscapeUI.SetActive(true);
    }

    public void ShowGameOverMenu()
    {
        GameOverUI.SetActive(true);
    }

    public void ResumeGame()
    {
        EscapeUI.SetActive(false);
    }

    public void NextLvl()
    {
        gameManager.NextLvl();
    }
}
