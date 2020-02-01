using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillInventory : MonoBehaviour
{

    public List<Piece> listPieces;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddObjectToDrill(Piece piece)
    {
        if (piece == null)
        {
            Debug.Log("No pieces");
            return;
        }
            listPieces.Add(piece);
    }

}
