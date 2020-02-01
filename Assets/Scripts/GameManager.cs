using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
        Debug.Log("Starting Game");
        SceneManager.LoadScene("Loic");
     }

    public void QuitGame()
    {
        Debug.Log("Leaving Game");
    }
}
