using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PoisonedItemSpawner : MonoBehaviour
{
    public static Action<Transform> OnPoisonedItemSpawned;
    [SerializeField] private Item _poisonedItem; 
    [SerializeField] private GameObject poisonedPowerupPrefab;
    [SerializeField] private PathFinder _pathFinder;
    public List<Transform> nodes = new List<Transform>();
    [SerializeField] private List<Transform> nodesToNotSpawnIn = new List<Transform>();

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
        int randomIndex = UnityEngine.Random.Range(0, nodes.Count);
        Transform randomNode = nodes[randomIndex];
        GameObject poisonedGameObject = Instantiate(poisonedPowerupPrefab, randomNode.position, Quaternion.identity, transform);
        OnPoisonedItemSpawned?.Invoke(randomNode);
        
        ItemLocation poisonedItemLocation = new ItemLocation();
        poisonedItemLocation.item = _poisonedItem;
        poisonedItemLocation.location = randomNode.GetChild(0);

        LocationOfItemsManager.Instance.AddItemLocation(poisonedItemLocation);
    }
}

#region Editor
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
#endregion