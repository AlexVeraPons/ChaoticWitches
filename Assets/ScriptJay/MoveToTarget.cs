using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] public Transform target;
    [SerializeField] private GameObject listFillerPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GoToTarget();
    }

    private void GoToTarget()
    {
        if(target != null)
        {
            //agent.SetDestination(target.position);
        }
        return;
    }

    public void NextTarget(Transform nextTarget)
    {
        Instantiate(listFillerPrefab);
        target = nextTarget;
    }
}
