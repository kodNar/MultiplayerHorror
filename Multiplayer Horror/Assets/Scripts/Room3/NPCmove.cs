using UnityEngine;
using UnityEngine.AI;

    public class NPCmove : MonoBehaviour
    {
        //[SerializeField] private Transform destination;

        private NavMeshAgent navMeshAgent;
        public GameObject destination;
        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();

            if (navMeshAgent == null)
            {
                Debug.Log("The navmesh-component is not attached to the " + gameObject.name);
            }
        }

        private void Update()
        {
            Vector3 targetVector = destination.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }
    }

