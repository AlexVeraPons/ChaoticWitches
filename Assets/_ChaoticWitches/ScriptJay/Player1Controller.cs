using UnityEngine;
using UnityEngine.AI;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PathFinder pathFinder;
    [SerializeField] private LayerMask Nodes;

    [SerializeField] private Material tilesPlayer1;
    [SerializeField] private Material tilesPlayer2;

    private Transform destination;

    public bool startedMoving = false;

    public int stepAmount;

    public bool itIsMyTurn = false;
    [SerializeField] private bool isPlayer1;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pathFinder = GetComponent<PathFinder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itIsMyTurn)
        {
            SetStepAmount();
            SetTargetColor();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!startedMoving && itIsMyTurn)
        {
            if (collision.gameObject.CompareTag("Nodes"))
            {

                pathFinder.startNode = collision.transform;
                startedMoving = true;
            }

            if (collision.gameObject.transform == destination)
            {
                EndTurn();
            }
        }
    }

    public void SetSteps(int amountOfSteps)
    {
        stepAmount = amountOfSteps;
    }

    public void SetNewTarget(Transform targetNode)
    {
        agent.SetDestination(targetNode.transform.position);
        destination = targetNode;
    }

    private void SetTargetColor()
    {
        if (stepAmount > 0 && pathFinder.nodes.Count >= stepAmount)
        {
            if (isPlayer1)
            {
                pathFinder.nodes[stepAmount].gameObject.GetComponent<MeshRenderer>().material = tilesPlayer1;
            } else if (!isPlayer1)
            {
                pathFinder.nodes[stepAmount].gameObject.GetComponent<MeshRenderer>().material = tilesPlayer2;
            }
        }
    }

    private void SetStepAmount()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stepAmount = 1;
        }
    }

    private void EndTurn()
    {
        Debug.Log("end turn");
    }
}
