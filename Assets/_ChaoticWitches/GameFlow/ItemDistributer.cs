using System.Collections.Generic;
using UnityEngine;

public class ItemDistributer : MonoBehaviour
{
    [SerializeField] private TeamManager _teamManager;
    [SerializeField] private List<ItemPossibility> _itemPossibilities = new List<ItemPossibility>();

    [System.Serializable]
    private class ItemPossibility
    {
        public List<Item> itemsTeam1;
        public List<Item> itemsTeam2;
    }

    private void Start()
    {
        int randomIndex = Random.Range(0, _itemPossibilities.Count);

        Item[] itemsTeam1 = _itemPossibilities[randomIndex].itemsTeam1.ToArray();
        Item[] itemsTeam2 = _itemPossibilities[randomIndex].itemsTeam2.ToArray();
        
        _teamManager.GetTeam1().PotInventory.AssignNeededItems(itemsTeam1);
        _teamManager.GetTeam2().PotInventory.AssignNeededItems(itemsTeam2);
    }
}

