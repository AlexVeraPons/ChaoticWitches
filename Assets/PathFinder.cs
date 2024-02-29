using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public List<Transform> nodes = new List<Transform>();

    [SerializeField] private MapConnections mapConnections;
    public Transform startNode;
    public Transform targetNode;

    public static PathFinder instance { get; private set; }

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        mapConnections = GetComponent<MapConnections>();

        //Debug.Log(nodes[0]);
    }

    private void Update()
    {
        List<Transform> path = FindShortestPath(startNode, targetNode);
        if (path != null)
        {
            nodes = path;
        }
        else
        {
            Debug.Log("Path not found");
        }
    }

    public List<Transform> FindShortestPath(Transform start, Transform target)
    {
        Queue<Transform> queue = new Queue<Transform>();
        Dictionary<Transform, Transform> cameFrom = new Dictionary<Transform, Transform>();
        HashSet<Transform> visited = new HashSet<Transform>();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            Transform current = queue.Dequeue();

            if (current == target)
            {
                // Reconstruct path
                return ReconstructPath(cameFrom, start, target);
            }

            List<Transform> neighbors = mapConnections.GetConnections(current);

            foreach (Transform neighbor in neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                    cameFrom[neighbor] = current;
                }
            }
        }

        // No path found
        return null;
    }

    private List<Transform> ReconstructPath(Dictionary<Transform, Transform> cameFrom, Transform start, Transform target)
    {
        List<Transform> path = new List<Transform>();
        Transform current = target;

        while (current != start)
        {
            path.Add(current);
            current = cameFrom[current];
        }
        path.Add(start);

        path.Reverse();
        return path;
    }
}
