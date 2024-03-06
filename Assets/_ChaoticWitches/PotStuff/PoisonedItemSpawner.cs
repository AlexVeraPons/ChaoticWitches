using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PoisonedItemSpawner : MonoBehaviour
{
    public static Action<Transform> OnPoisonedItemSpawned;
    [SerializeField] private GameObject poisonedPowerupPrefab;
    [SerializeField] private PathFinder _pathFinder;
    public List<Transform> nodes = new List<Transform>();
    [SerializeField] private List<Transform> nodesToNotSpawnIn = new List<Transform>();

    private void Awake()
    {
        // nodes = _pathFinder.nodes;
    }

    private void Start()
    {
        foreach (Transform node in nodesToNotSpawnIn)
        {
            nodes.Remove(node);
        }

        SpawnPoisonedItem();
    }

    public void SpawnPoisonedItem()
    {
        Debug.Log("Spawning Poisoned Item!");
        int randomIndex = UnityEngine.Random.Range(0, nodes.Count);
        Debug.Log("ammount of nodes is " + nodes.Count);
        Transform randomNode = nodes[randomIndex];
        GameObject something = Instantiate(poisonedPowerupPrefab, randomNode.position, Quaternion.identity, transform);
        Debug.Log("is GameObject real  " + something != null);
        OnPoisonedItemSpawned?.Invoke(randomNode);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(PoisonedItemSpawner))]
public class PoisonedItemSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // add selected to node list button
        if (GUILayout.Button("Add selected to node list"))
        {
            PoisonedItemSpawner spawner = (PoisonedItemSpawner)target;
            foreach (GameObject go in Selection.gameObjects)
            {
                Transform transform = go.transform;
                if (!spawner.nodes.Contains(transform))
                {
                    spawner.nodes.Add(transform);
                }
            }

            EditorUtility.SetDirty(spawner);
        }

        // rest of the editor 
        base.OnInspectorGUI();
    }
}

#endif