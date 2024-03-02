using UnityEngine;
using UnityEngine.AI;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PathFinder pathFinder;
    [SerializeField] private LayerMask Nodes;

    public bool startedMoving = false;

    public int stepAmount;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pathFinder = GameObject.Find("MapConnections").GetComponent<PathFinder>();
    }

    // Update is called once per frame
    void Update()
    {
        SetStepAmount();
        SetNewTarget();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nodes"))
        {
            if (!startedMoving)
            {
                pathFinder.startNode = collision.transform;
                startedMoving = true;
            }
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.transform == pathFinder.nodes[stepAmount].transform)
    //    {
    //        startedMoving = false;
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
        
    //}

    public void SetSteps(int amountOfSteps)
    {

    }

    private void SetNewTarget()
    {
        if(stepAmount > 0 && pathFinder.nodes.Count >= stepAmount)
        {
            agent.SetDestination(pathFinder.nodes[stepAmount].position);
        } else
        {
            return;
        }
    }

    private void SetStepAmount()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            stepAmount = 1;
        }
    }
}
