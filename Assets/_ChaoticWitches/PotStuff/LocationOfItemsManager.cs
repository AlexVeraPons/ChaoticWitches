using System.Collections.Generic;
using UnityEngine;

public class LocationOfItemsManager : MonoBehaviour {

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
            Destroy(gameObject);
    }
    #endregion
    
    Dictionary<Item, Transform> locationOfItems = new Dictionary<Item, Transform>();

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
}

