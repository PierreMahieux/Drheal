using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject drill;
    public GameObject canevas;
    public GameObject prefabPiece;
    public GameObject prefabEnnemy;
    public MenuManager menuManager;
    public PlayerMovement playerMovement;

    private Vector3 Min;
    private Vector3 Max;
    private float _xAxis;
    private float _yAxis;
    private float _zAxis;
    private Vector3 _randomPosition;

    private List<Vector3> possiblePiecesSpawn;

    public int numberOfPieceToWin = 5;
    public int numberOfEnnemies = 3;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        UnPauseGame();
        menuManager.HideAllUIs();
        possiblePiecesSpawn = new List<Vector3>() {new Vector3(9.71f,0f,-9.17f), new Vector3(22.53f,0f,-5.58f),
            new Vector3(35.71f,0f,13.83f), new Vector3(21.19f,0f,-9.17f), new Vector3(1.4f, 0f, 10.17f), new Vector3(11.89f,0f,10.97f), new Vector3(11.89f,0f,1.24f)};

        for (int i = 0; i < numberOfPieceToWin; i++)
        {
            //Instantiate(prefabPiece, possiblePiecesSpawn[0], Quaternion.identity);
            //possiblePiecesSpawn.RemoveAt(0);

            Instantiate(prefabPiece, GetRandomLocation(), Quaternion.identity);
        }

        for (int i = 0; i < numberOfEnnemies; i++)
        {
            Instantiate(prefabEnnemy, GetRandomLocation(), Quaternion.identity);
        }

        PlayerStats.currentHealth = PlayerStats.maxHealth;
    }

    internal void PauseGame()
    {
        Time.timeScale = 0;
        playerMovement.canMove = false;
    }

    internal void UnPauseGame()
    {
        Time.timeScale = 1;
        playerMovement.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        WinGame();
        GameOver();

        if (Input.GetKey(KeyCode.Escape))
        {
            menuManager.ShowEscapeMenu();
        }

    }


    public void WinGame()
    {
        DrillInventory inv = drill.GetComponent<DrillInventory>();
        if (inv)
        {
            if (inv.listPieces.Count == numberOfPieceToWin)
            {
                // Debug.LogWarning("Win");
                PauseGame();
                menuManager.ShowWinMenu();
            }
        }
    }

    private void SetRanges()
    {
        Min = new Vector3(-15, 0, -15);
        Max = new Vector3(15, 0, 15);
    }

    private void InstantiateRandomObjects()
    {
        if (prefabPiece)
        {
            GenerateNewRamdomPosition();
            Instantiate(prefabPiece, _randomPosition, Quaternion.identity);
        }

    }

    public void GenerateNewRamdomPosition()
    {
        _xAxis = UnityEngine.Random.Range(Min.x, Max.x);
        _yAxis = UnityEngine.Random.Range(Min.y, Max.y);
        _zAxis = UnityEngine.Random.Range(Min.z, Max.z);

        _randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);
    }

    public void NextLvl()
    {
        PlayerStats.score++;
        SceneManager.LoadScene("BasicLevel");
    }

    public void GameOver()
    {
        if (PlayerStats.currentHealth == 0)
        {
            PlayerStats.currentHealth = -1;
            menuManager.ShowGameOverMenu();
            PauseGame();
        }
    }


    Vector3 GetRandomLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        // Pick the first indice of a random triangle in the nav mesh
        int t = UnityEngine.Random.Range(0, navMeshData.indices.Length - 3);

        // Select a random point on it
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], UnityEngine.Random.value);
        Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], UnityEngine.Random.value);

        return point;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        // Debug.Log("Starting Game");
        SceneManager.LoadScene("BasicLevel");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
