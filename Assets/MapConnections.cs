using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MapConnections : MonoBehaviour
{
    [Serializable]
    public class Connection
    {
        public Transform nodeA;
        public Transform nodeB;
    }

    [SerializeField] private List<Connection> connections = new List<Connection>();

    private Dictionary <Transform, List<Transform>>  connectionMap = new Dictionary<Transform, List<Transform>>();
    private readonly List<Transform> nullList = new List<Transform>();

    // Start is called before the first frame update
    void Awake()
    {
        foreach (var connection in connections)
        {
            Map(connection.nodeA, connection.nodeB);
            Map(connection.nodeB, connection.nodeA);
        }
    }

    private void Map (Transform nodeA, Transform nodeB)
    {
        List<Transform> connections;

        if (connectionMap.ContainsKey(nodeA))
        {
            connections = connectionMap[nodeA];
        }
        else
        {
            connections = new List<Transform>();
            connectionMap.Add(nodeA, connections);
        }

        connections.Add(nodeB);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (var connection in connections) { 
            Vector3 direction = connection.nodeB.position - connection.nodeA.position;
            Vector3 normal = Vector3.Cross(Vector3.up, direction);

            for (int i = 0; i < 5 ; i++)
            {
                Gizmos.DrawLine(connection.nodeA.position + i * 0.01f * normal, connection.nodeB.position + i * 0.01f * normal);
            }
        }
    }

    public List<Transform> GetConnections(Transform pNode)
    {
        if (connectionMap.ContainsKey (pNode))
        {
            return connectionMap[pNode];
        }
        else
        {
            return nullList;
        }
    }
}
