using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Player1Controller : MonoBehaviour
{
    public static Action OnTurnEnded;

    [SerializeField] private PathFinder pathFinder;
    [SerializeField] private LayerMask Nodes;

    [SerializeField] private Material nodesPlayer1;
    [SerializeField] private Material nodesPlayer2;
    [SerializeField] private Material originalNodeMaterial;

    [SerializeField] private Material oldOriginalNodeMaterial;
    [SerializeField] private Transform oldNodeTransform;
    private bool hasResetColor = false;
    private bool isOriginalNodeMaterialSet = false;

    [SerializeField] private Player1Controller otherPlayer;

    [SerializeField]private Transform gateLocation;
    public Transform destination;
    public Transform swapLocation;
    public bool haveSwapped = false;

    public bool startedMoving = false;

    public int stepAmount;
    private int oldStepAmmount;
    private int leftOverSteps;

    public bool itIsMyTurn = false;
    public bool isPlayer1;

    private int currentIndex = 1;
    private int newCurrentIndex;

    public bool targetIsSet = false;

    public List<Transform> inBetweenSteps = new List<Transform>();

    public bool hasPressed = false;

    private bool listIsFilled = false;

    private int destinationIndex = 0;
    private Transform begin;
    private Transform end;

    [SerializeField] private float speed;
    private float timeToTarget;
    private float elapsedTime;

    public bool canSetNewTarget = true;

    private bool isItemReachable = false;

    public bool canMultiplySteps = false;

    public int victoryScene;

    void Awake()
    {
        pathFinder = GetComponent<PathFinder>();
        if (isPlayer1)
        {
            otherPlayer = GameObject.Find("Player2").GetComponent<Player1Controller>();
        }
        else
        {
            otherPlayer = GameObject.Find("Player1").GetComponent<Player1Controller>();

        }
    }

    void FixedUpdate()
    {
        if (TeamManager.Instance.GetCurrentTeam().PotInventory.CheckIfAllItemsGathered()){
            SetTargetToGate();
        }

        if (itIsMyTurn)
        {
            SetTargetColor();
            if (listIsFilled)
            {
                MovePlayer();
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Nodes"))
        {
            if (!startedMoving && itIsMyTurn)
            {
                pathFinder.startNode = collision.transform;
                startedMoving = true;
            }

            if (!haveSwapped)
            {
                swapLocation = collision.transform;
            }

            if (haveSwapped && collision.gameObject.transform == otherPlayer.swapLocation)
            {
                haveSwapped = false;
                otherPlayer.haveSwapped = false;
            }
        }
    }

    public void FillInBetweenList()
    {
        for (int i = 0; i <= stepAmount; i++)
        {
            inBetweenSteps.Add(pathFinder.nodes[i].parent);
            Debug.Log(pathFinder.nodes[i].parent);
        }
        hasPressed = true;
        listIsFilled = true;
    }

    private void SetTargetColor()
    {
        if (stepAmount >= pathFinder.nodes.Count - 1 && targetIsSet && !isItemReachable)
        {
            isItemReachable = true;
            oldStepAmmount = stepAmount;
            stepAmount = pathFinder.nodes.Count - 1;
            leftOverSteps = oldStepAmmount - stepAmount;
        }

        if (stepAmount > 0 && pathFinder.nodes.Count > stepAmount)
        {
            if (!isOriginalNodeMaterialSet)
            {
                originalNodeMaterial = pathFinder.nodes[stepAmount].gameObject.GetComponent<MeshRenderer>().material;
                isOriginalNodeMaterialSet = true;
            }

            if (!hasResetColor)
            {
                oldOriginalNodeMaterial = pathFinder.nodes[stepAmount].gameObject.GetComponent<MeshRenderer>().material;
                oldNodeTransform = pathFinder.nodes[stepAmount].transform;
                oldNodeTransform.gameObject.GetComponent<MeshRenderer>().material = oldOriginalNodeMaterial;
                hasResetColor = true;
            }

            if (isPlayer1)
            {
                if (pathFinder.nodes.Count > 1)
                {
                    pathFinder.nodes[stepAmount].gameObject.GetComponent<MeshRenderer>().material = nodesPlayer1;
                }
                else if(stepAmount >= pathFinder.nodes.Count  - 1)
                {
                    pathFinder.nodes[pathFinder.nodes.Count].GetComponent<MeshRenderer>().material = nodesPlayer1;
                }
            }
            else if (!isPlayer1)
            {
                if (pathFinder.nodes.Count > 1)
                {
                    pathFinder.nodes[stepAmount].gameObject.GetComponent<MeshRenderer>().material = nodesPlayer2;
                }
                else if (stepAmount >= pathFinder.nodes.Count - 1)
                {
                    pathFinder.nodes[pathFinder.nodes.Count].GetComponent<MeshRenderer>().material = nodesPlayer2;
                }
            }
        }
    }

    public void SetNextTargetInList()
    {
        if (stepAmount == 0)
        {
            Debug.Log(stepAmount);
            return;
        }

        if (destinationIndex != inBetweenSteps.Count - 1)
        {
            destinationIndex++;
            begin = inBetweenSteps[destinationIndex - 1].transform;
            end = inBetweenSteps[destinationIndex].transform;

            elapsedTime = 0f;

            float distanceToTarget = Vector3.Distance(begin.position, end.position);
            timeToTarget = distanceToTarget / speed;
        }
        else if (destinationIndex == inBetweenSteps.Count - 1 && leftOverSteps == 0)
        {
            EndTurn();
        }
        else
        {
            SelectedTargetReached();
        }
    }

    private void MovePlayer()
    {
        elapsedTime += Time.deltaTime;

        float elapsedPercentage = elapsedTime / timeToTarget;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        Vector3 beginLockedY = new Vector3(begin.position.x, gameObject.transform.position.y, begin.position.z);
        Vector3 endLockedY = new Vector3(end.position.x, gameObject.transform.position.y, end.position.z);

        transform.position = Vector3.Lerp(beginLockedY, endLockedY, elapsedPercentage);

        if (elapsedPercentage >= 1)
        {
            SetNextTargetInList();
        }
    }

    private void SelectedTargetReached()
    {
        //TODO: code to execute when the player has reached the item they chose in the UI

        if (TeamManager.Instance.GetCurrentTeam().PotInventory.CheckIfAllItemsGathered()){
            SceneManager.LoadScene(victoryScene);
        }

        Debug.Log("destination reached");
        ResetTargetMaterial();
        hasPressed = false;
        startedMoving = false;
        destination = null;
        listIsFilled = false;
        canSetNewTarget = true;
        targetIsSet = false;
        isItemReachable = false;
        inBetweenSteps.Clear();
        pathFinder.nodes.Clear();
        stepAmount = leftOverSteps;
        leftOverSteps = 0;
        oldStepAmmount = 0;
        destinationIndex = 0;
        elapsedTime = 0;
    }

    private void EndTurn()
    {
        Debug.Log("end turn");
        ResetTargetMaterial();
        itIsMyTurn = false;
        otherPlayer.itIsMyTurn = true;
        hasPressed = false;
        startedMoving = false;
        destination = null;
        listIsFilled = false;
        isOriginalNodeMaterialSet = false;
        inBetweenSteps.Clear();
        pathFinder.nodes.Clear();
        stepAmount = 0;
        destinationIndex = 0;
        elapsedTime = 0;

        Player1Controller.OnTurnEnded?.Invoke();
    }



    public void SetTarget(Transform newTarget)
    {
        targetIsSet = true;
        canSetNewTarget = false;
        pathFinder.targetNode = newTarget;
    }

    public void SetSteps(int amountOfSteps)
    {
        stepAmount = amountOfSteps;
    }

    public void SetTargetToGate()
    {
        pathFinder.targetNode = gateLocation;
    }

    private void ResetTargetMaterial()
    {
        pathFinder.nodes[stepAmount].gameObject.GetComponent<MeshRenderer>().material = originalNodeMaterial;
    }

    public void ResetNodeColor()
    {
        if(oldNodeTransform != null)
        {
            oldNodeTransform.gameObject.GetComponent<MeshRenderer>().material = oldOriginalNodeMaterial;
            hasResetColor = false;
        }
    }
}
