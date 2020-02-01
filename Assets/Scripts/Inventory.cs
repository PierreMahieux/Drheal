using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Piece> MesPieces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Piece")
        {
            MesPieces.Add(other.GetComponent<Piece>());
            other.gameObject.SetActive(false);
            foreach (var item in MesPieces)
            {
                Debug.Log(item.Nom);
            }
        }
    }
}
