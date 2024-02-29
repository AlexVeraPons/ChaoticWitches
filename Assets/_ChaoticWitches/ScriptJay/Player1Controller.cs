using UnityEngine;
using UnityEngine.AI;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PathFinder pathFinder;

    private bool startedMoving = false;

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
        SetNewTarget();
        SetStepAmount();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nodes"))
        {
            Debug.Log(collision.transform);
            if (!startedMoving)
            {
                pathFinder.startNode = collision.transform;
                startedMoving = true;
            }

            //TODO: make script for ending turn

            //if(stepAmount < pathFinder.nodes.Count && stepAmount > pathFinder.nodes.Count) { stepAmount = 0; }
            //else if (collision.transform == pathFinder.nodes[stepAmount])
            //{

            //}
        }
    }

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
            stepAmount = 2;
        }
    }
}
