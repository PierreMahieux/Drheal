using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject drill;
    public GameObject canevas;
    public GameObject prefabPiece;

    private Vector3 Min;
    private Vector3 Max;
    private float _xAxis;
    private float _yAxis;
    private float _zAxis; 
    private Vector3 _randomPosition;

    private int numberOfPieceToWin = 5;


    // Start is called before the first frame update
    void Start()
    {
        SetRanges();

        for (int i = 0; i < numberOfPieceToWin; i++)
        {
            InstantiateRandomObjects();
        }

    }

    // Update is called once per frame
    void Update()
    {
        WinGame();

    }


    public void WinGame()
    {
        DrillInventory inv = drill.GetComponent<DrillInventory>();
        if (inv)
        {
            if (inv.listPieces.Count == numberOfPieceToWin)
            {
                // Debug.LogWarning("Win");
                canevas.SetActive(true);
            }
        }
    }

    private void SetRanges()
        {
            Min = new Vector3(0, 0, 0); 
            Max = new Vector3(15, 1, 15); 
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

}
