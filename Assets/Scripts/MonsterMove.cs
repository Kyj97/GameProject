using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public float updateInterval = 3f; 
    private NavMeshAgent agent;
    private float timeSinceLastUpdate;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timeSinceLastUpdate = updateInterval; 
    }

    void Update()
    {
        timeSinceLastUpdate += Time.deltaTime; 

        if (timeSinceLastUpdate >= updateInterval)
        {
            Vector3 randomPosition = GetRandomPositionOnNavMesh(); 
            agent.SetDestination(randomPosition); 
            timeSinceLastUpdate = 0f; 
        }
    }

    Vector3 GetRandomPositionOnNavMesh()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 20f; 
        randomDirection += transform.position; 

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 20f, NavMesh.AllAreas)) 
        {
            return hit.position; 
        }
        else
        {
            return transform.position; 
        }
    }


}
