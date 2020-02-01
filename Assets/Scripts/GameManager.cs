﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject drill;
    public GameObject canevas;
    public GameObject prefabPiece;
    public MenuManager menuManager;

    private Vector3 Min;
    private Vector3 Max;
    private float _xAxis;
    private float _yAxis;
    private float _zAxis; 
    private Vector3 _randomPosition;

    private List<Vector3> possiblePiecesSpawnPositions;
    
    private int numberOfPieceToWin = 5;


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //SetRanges();

        //for (int i = 0; i < numberOfPieceToWin; i++)
        //{
        //    InstantiateRandomObjects();
        //}
        //Debug.Log(PlayerStats.score);

        possiblePiecesSpawnPositions = new List<Vector3>() {new Vector3(8.97f,0f,-9.17f), new Vector3(22.53f,0f,-5.58f),
            new Vector3(35.71f,0f,13.83f), new Vector3(21.19f,0f,-9.17f), new Vector3(1.4f, 0f, 10.17f), new Vector3(11.89f,0f,10.97f), new Vector3(11.89f,0f,1.24f)};

        for (int i = 0; i < numberOfPieceToWin; i++)
        {
            Instantiate(prefabPiece, possiblePiecesSpawnPositions[i], Quaternion.identity);

        }
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
        SceneManager.LoadScene("Loic");
    }

    public void GameOver()
    {
        if (PlayerStats.currentHealth == 0)
        {
            menuManager.ShowGameOverMenu();
        }
    }
}
