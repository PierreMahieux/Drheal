using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Piece> mesPieces;
    public GameObject ThirdPersonPlayer;
    private Collider drillCollider;

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
        drillCollider = other;
        if (other.tag=="Piece")
        {
            mesPieces.Add(other.GetComponent<Piece>());
            //other.gameObject.SetActive(false);
            other.gameObject.transform.SetParent(ThirdPersonPlayer.transform);
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.transform.localScale = new Vector3(other.gameObject.transform.localScale.x / 2, other.gameObject.transform.localScale.y / 2, other.gameObject.transform.localScale.z / 2);
        }

        if (other.tag == "Finish")
        {
            //Debug.Log("Colision Drill");
            //Debug.Log("collide Drill\nliste pièces : " + mesPieces.Count);
            StartCoroutine("CoroutineAddObjectToDrill");
            //mesPieces.Clear();
        }
    }

    public IEnumerator CoroutineAddObjectToDrill()
    {
        gameObject.GetComponent<PlayerMovement>().canMove = false;
        int countpiece = mesPieces.Count;
        for (int i = 0; i < (countpiece); i++)
        {
            Piece currentPiece = mesPieces[0];
            drillCollider.gameObject.GetComponent<DrillInventory>().AddObjectToDrill(currentPiece);
            mesPieces.RemoveAt(0);
            Destroy(currentPiece.gameObject);
            Debug.Log("Coroutine Boucle :" + i);
            yield return new WaitForSeconds(0.2f);
        }
        gameObject.GetComponent<PlayerMovement>().canMove = true;
    }
}
