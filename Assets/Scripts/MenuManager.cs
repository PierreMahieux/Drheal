using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject canevas;
    public GameObject winUI;
    public GameObject EscapeUI;
    public GameObject GameOverUI;

    public Inventory PlayerInventory;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //EscapeUI = canevas.transform.Find("EscapeUI").gameObject;
        if (!PlayerInventory)
        {
            PlayerInventory = FindObjectOfType<Inventory>();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            canevas.transform.Find("Image").gameObject.SetActive(false);
        }
        UpdatePlayerUI();
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

    internal void HideAllUIs()
    {
        winUI.SetActive(false);
        EscapeUI.SetActive(false);
        GameOverUI.SetActive(false);
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

    public void ShowAboutMenu()
    {
        canevas.transform.Find("Image").gameObject.SetActive(true);
    }

    public void UpdatePlayerUI()
    {
        canevas.transform.Find("PlayerUI").Find("TextScore").GetComponent<Text>().text = "LVL : " + PlayerStats.score ;
        canevas.transform.Find("PlayerUI").Find("TextHealth").GetComponent<Text>().text = "Health : " + PlayerStats.currentHealth + "/" + PlayerStats.maxHealth ;
        canevas.transform.Find("PlayerUI").Find("TextPieces").GetComponent<Text>().text = "Piece : " + PlayerInventory.mesPieces.Count + "/" + gameManager.numberOfPieceToWin;
    }
}
