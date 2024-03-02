using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetButton : MonoBehaviour
{
    [SerializeField] private PathFinder pathFinderPlayer1;
    [SerializeField] private PathFinder pathFinderPlayer2;

    [SerializeField] private Transform target8;
    [SerializeField] private Transform target3;
    [SerializeField] private Transform target4;
    [SerializeField] private Transform target6;

    //private int stepAmount2 = 2;
    //private int stepAmount5 = 5;

    public void Start()
    {
        pathFinderPlayer1 = GameObject.Find("Player1").GetComponent<PathFinder>();
        pathFinderPlayer2 = GameObject.Find("Player2").GetComponent<PathFinder>();
    }
    public void SetTargetTo8()
    {
        pathFinderPlayer1.targetNode = target8;
        pathFinderPlayer2.targetNode = target8;
    }

    public void SetTargetTo3()
    {
        pathFinderPlayer1.targetNode = target3;
        pathFinderPlayer2.targetNode = target3;
    }

    public void SetTargetTo4()
    {
        pathFinderPlayer1.targetNode = target4;
        pathFinderPlayer2.targetNode = target4;
    }

    public void SetTargetTo6()
    {
        pathFinderPlayer1.targetNode = target6;
        pathFinderPlayer2.targetNode = target6;
    }
}
