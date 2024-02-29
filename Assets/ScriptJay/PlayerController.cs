using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private WaypointController waypointController;
    [SerializeField] private float speed;

    private int targetWaypointIndex;

    private Transform previousWaypoint;
    private Transform targetWaypoint;

    private float timeToWaypoint;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
        Debug.Log("PLatformController set");
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        float elapsedPercentage = elapsedTime / timeToWaypoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        transform.position = Vector3.Lerp(previousWaypoint.position, targetWaypoint.position, elapsedPercentage);
        if(elapsedPercentage >= 1 )
        {
            TargetNextWaypoint();
        }
    }

    private void TargetNextWaypoint()
    {
        Debug.Log("Targeting next waypoint");
        if(waypointController == null)
        {
            Debug.Log("Waypoint controller not set");
            return;
        }

        previousWaypoint = waypointController.GetWaypoint(targetWaypointIndex);
        targetWaypointIndex = waypointController.GetNextWaypointIndex(targetWaypointIndex);
        targetWaypoint = waypointController.GetWaypoint(targetWaypointIndex);

        elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(previousWaypoint.position, targetWaypoint.position);
        timeToWaypoint = distanceToWaypoint/speed;
    }
}
