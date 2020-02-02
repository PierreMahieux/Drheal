using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool canMove=false;
    public GameObject target;
    public int damages = 1;
    public float distanceStop = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target.gameObject.transform.position, transform.position);

        if (canMove)
        {
            if (agent)
            {
                if(distance <= distanceStop)
                {
                    agent.isStopped = true;
                    agent.velocity = Vector3.zero;
                    Hurt();
                    Debug.Log("aie");
                    Destroy(gameObject);
                }
                else
                {
                    agent.isStopped = false;
                    agent.destination = target.gameObject.transform.position;
                }
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


    private void Hurt()
    {
        PlayerStats.currentHealth = PlayerStats.currentHealth - damages;
    }
}
