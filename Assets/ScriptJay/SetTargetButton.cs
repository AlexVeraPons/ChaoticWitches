using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetButton : MonoBehaviour
{
    [SerializeField] private PathFinder pathFinder;

    [SerializeField] private Transform target8;
    [SerializeField] private Transform target3;
    [SerializeField] private Transform target4;
    [SerializeField] private Transform target6;

    //private int stepAmount2 = 2;
    //private int stepAmount5 = 5;

    public void Start()
    {
        pathFinder = GameObject.Find("MapConnections").GetComponent<PathFinder>();
    }
    public void SetTargetTo8()
    {
        pathFinder.targetNode = target8;
    }

    public void SetTargetTo3()
    {
        pathFinder.targetNode = target3;
    }

    public void SetTargetTo4()
    {
        pathFinder.targetNode = target4;
    }

    public void SetTargetTo6()
    {
        pathFinder.targetNode = target6;
    }

    public void SetStepsTo2()
    {

    }

    public void SetStepsTo5()
    {
        
    }
}
