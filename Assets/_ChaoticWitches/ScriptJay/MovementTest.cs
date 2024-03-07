using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    [SerializeField] private PathFinder pathFinder;

    public Transform destination;

    public int stepAmmount;

    public List<Transform> inBetweenSteps = new List<Transform>();

    public bool hasPressed = false;

    private bool listIsFilled = false;

    private int destinationIndex = 0;
    private Transform begin;
    private Transform end;

    [SerializeField] private float speed;
    private float timeToWaypoint;
    private float elapsedTime;

    private bool callMeOnce = false;


    // Start is called before the first frame update
    void Awake()
    {
        pathFinder = GetComponent<PathFinder>();
        FillInBetweenList();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!callMeOnce)
        {
            SetNextTargetInList();
            callMeOnce = true;
        }

        if (listIsFilled)
        {
            elapsedTime = Time.deltaTime;

            float elapsedPercentage = elapsedTime / timeToWaypoint;
            elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
            Debug.Log(begin.parent.transform);
            Debug.Log(end.parent.transform);
            transform.position = Vector3.Lerp(begin.parent.position, end.parent.position, elapsedPercentage);

            if(elapsedPercentage >= 1)
            {
                SetNextTargetInList();
            }
        }
    }

    public void FillInBetweenList()
    {
        for(int i = 1; i <= stepAmmount; i++)
        {
            inBetweenSteps.Add(pathFinder.nodes[stepAmmount]);
        }
        hasPressed = true;
        listIsFilled = true;
    }

    private void SetNextTargetInList()
    {
        if (stepAmmount == 0)
        {
            return;
        }

        destinationIndex++;
        begin = pathFinder.nodes[destinationIndex - 1];
        end = pathFinder.nodes[destinationIndex];

        elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(begin.parent.position, end.parent.position);
        timeToWaypoint = distanceToWaypoint / speed;
    }
}
