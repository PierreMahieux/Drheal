using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool canMove=false;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (agent)
            {
                agent.destination = target.gameObject.transform.position;
                //agent.SetDestination(other.gameObject.transform.position);
            }
            else
            {
                Debug.LogError("No navmesh");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            target = other.gameObject;
            canMove = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            target = null;
            canMove = false;
        }
    }
}
