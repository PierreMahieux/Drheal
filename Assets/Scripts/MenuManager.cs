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

    public void PlayGame()
    {
        // Debug.Log("Starting Game");
        SceneManager.LoadScene("BasicLevel");
    }
    public void QuitGame()
    {
        // Debug.Log("Leaving Game");
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowWinMenu()
    {
        winUI.SetActive(true);
    }

    public void ShowEscapeMenu()
    {
        gameManager.PauseGame();
        EscapeUI.SetActive(true);
    }

    public void ShowGameOverMenu()
    {
        GameOverUI.SetActive(true);
    }

    public void ResumeGame()
    {
        gameManager.UnPauseGame();
        EscapeUI.SetActive(false);
    }

    public void NextLvl()
    {
        gameManager.NextLvl();
    }

    public void Restart()
    {
        gameManager.PlayGame();
    }
}
