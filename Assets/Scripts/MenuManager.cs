using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject canevas;
    public GameObject winUI;
    public GameObject EscapeUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        // Debug.Log("Starting Game");
        SceneManager.LoadScene("Loic");
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
        EscapeUI.SetActive(true);
    }

    public void ResumeGame()
    {
        EscapeUI.SetActive(false);
    }

}
