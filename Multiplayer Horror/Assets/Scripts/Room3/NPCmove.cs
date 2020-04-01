using System;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.AI;

public class NPCmove : MonoBehaviour
{
    //[SerializeField] private Transform destination;

    private NavMeshAgent navMeshAgent;
    private GameObject destination;
    private float distanceFromPlayer;
    private GameObject targetDestination;
    private bool playerFound;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.Log("The navmesh-component is not attached to the " + gameObject.name);
        }

        navMeshAgent.enabled = false;
        Invoke(nameof(FindPlayer), 5f);
    }

    private void FindPlayer()
    {
        if (GameObject.FindGameObjectWithTag("Player") != true)
        {
            Debug.Log("no player exists");
            return;
            //rekursion fungerar
        }

        targetDestination = GameObject.FindGameObjectWithTag("Player");
        playerFound = true;
    }

    private void Update()
    {
        if (!playerFound)
        {
            return;
        }

        distanceFromPlayer = Vector3.Distance(targetDestination.transform.position, transform.position);
        if (distanceFromPlayer < 10)
        {
            navMeshAgent.enabled = true;
            Vector3 direction = targetDestination.transform.position;
            navMeshAgent.SetDestination(direction);
        }
    }
}