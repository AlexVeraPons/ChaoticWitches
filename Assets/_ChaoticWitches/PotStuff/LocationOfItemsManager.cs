using System.Collections.Generic;
using UnityEngine;

public class LocationOfItemsManager : MonoBehaviour
{

    #region Singleton
    public static LocationOfItemsManager Instance { get; private set; }

    void Awake()
    {
        transform.parent = null;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Destroying LocationOfItemsManager because it already exists.");
            Destroy(gameObject);
        }
    }
    #endregion
    Dictionary<Item, Transform> locationOfItems = new Dictionary<Item, Transform>();


    [SerializeField] private List<ItemLocation> itemLocations = new List<ItemLocation>();


    private void Start()
    {
        foreach (ItemLocation itemLocation in itemLocations)
        {
            locationOfItems.Add(itemLocation.item, itemLocation.location);
        }

    }
    public Transform GetLocationOfItem(Item item)
    {
        if (locationOfItems.ContainsKey(item))
        {
            return locationOfItems[item];
        }
        else
        {
            return null;
        }
    }

    public ItemLocation GetItemLocation(Item item)
    {
        foreach (ItemLocation itemLocation in itemLocations)
        {
            if (itemLocation.item == item)
            {
                return itemLocation;
            }
        }
        return new ItemLocation();
    }

    public void AddItemLocation(ItemLocation itemLocation)
    {
        itemLocations.Add(itemLocation);
        locationOfItems.Add(itemLocation.item, itemLocation.location);
    }

    public void RemoveItemLocation(ItemLocation itemLocation)
    {
        itemLocations.Remove(itemLocation);
        locationOfItems.Remove(itemLocation.item);
    }

    public void UpdateItemLocation(ItemLocation itemLocation)
    {
        for (int i = 0; i < itemLocations.Count; i++)
        {
            if (itemLocations[i].item == itemLocation.item)
            {
                itemLocations[i] = itemLocation;
                locationOfItems[itemLocation.item] = itemLocation.location;
                return;
            }
        }
    }
}

[System.Serializable]
public struct ItemLocation
{
    public Item item;
    public Transform location;
}

