using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PathFinder pathFinder;
    [SerializeField] private LayerMask Nodes;

    [SerializeField] private Material tilesPlayer1;
    [SerializeField] private Material tilesPlayer2;

    [SerializeField] private Player1Controller otherPlayer;

    private Transform destination;

    public Transform swapLocation;
    public bool haveSwapped = false;

    public bool startedMoving = false;

    public int stepAmount;

    public bool itIsMyTurn = false;
    public bool isPlayer1;




    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        pathFinder = GetComponent<PathFinder>();
        if (isPlayer1)
        {
            otherPlayer = GameObject.Find("Player2").GetComponent<Player1Controller>();
        } else
        {
            otherPlayer = GameObject.Find("Player1").GetComponent<Player1Controller>();

        }
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

        if (!haveSwapped && collision.gameObject.CompareTag("Nodes"))
        {
            swapLocation = collision.transform;
        }

        if (haveSwapped && collision.gameObject.transform == otherPlayer.swapLocation && collision.gameObject.CompareTag("Nodes"))
        {
            haveSwapped = false;
            otherPlayer.haveSwapped = false;
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
            }
            else if (!isPlayer1)
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
