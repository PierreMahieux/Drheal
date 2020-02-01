using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Piece> mesPieces;

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
            mesPieces.Add(other.GetComponent<Piece>());
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Finish")
        {
            //Debug.Log("collide Drill\nliste pièces : " + mesPieces.Count);
            for (int i=0;i<(mesPieces.Count);i++)
            {
                other.gameObject.GetComponent<DrillInventory>().AddObjectToDrill(mesPieces[i]);
            }

            mesPieces.Clear();
        }
    }
}
