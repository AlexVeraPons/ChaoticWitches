using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PotInventory : MonoBehaviour
{
    public UnityEvent OnPotInventoryFull;
    public Action<Item> OnItemGathered;
    public Action<Item> OnPoisonedPot;
    public Action<Item> OnUnpoisonedPot;
    [SerializeField] private Item[] _neededItems;
    private Item _itemNeededForCure;
    private bool _isPoisoned = false;
    private int GatheredItemsAmmount()
    {
        int gatheredItems = 0;
        foreach (Item item in _neededItems)
        {
            if (item.IsGathered())
            {
                gatheredItems++;
            }
        }
        return gatheredItems;
    }

    public Item[] GetNeededItems()
    {
        return _neededItems;
    }

    public void AssignNeededItems(Item[] items)
    {
        _neededItems = items;
    }

    public void TryGatherItem(Item item)
    {
        Item itemInInventory = Array.Find(_neededItems, i => i == item);

        if (itemInInventory != null && !itemInInventory.IsGathered())
        {
            itemInInventory.Gather();
            OnItemGathered?.Invoke(itemInInventory);
            if (IsPotInventoryGathered())
            {
                OnPotInventoryFull?.Invoke();
            }
        }
    }

    public void TryPoisionPot(out bool isPoisoned)
    {
        if(_itemNeededForCure != null)
        {
            isPoisoned = false;
            return;
        }

        if (IsPotInventoryGathered())
        {
            isPoisoned = _isPoisoned;
            return;
        }

        List<Item> notGatheredItems = new List<Item>();

        foreach (Item item in _neededItems)
        {
            if (!item.IsGathered())
            {
                notGatheredItems.Add(item);
            }
        }

        int randomIndex = UnityEngine.Random.Range(0, notGatheredItems.Count);
        Item randomItem = notGatheredItems[randomIndex];

        _isPoisoned = true;
        isPoisoned = _isPoisoned;
        _itemNeededForCure = randomItem;
        OnPoisonedPot?.Invoke(_itemNeededForCure);
    }

    public bool IsPotInventoryGathered()
    {
        foreach (Item item in _neededItems)
        {
            if (!item.IsGathered())
            {
                return false;
            }
        }

        return true;
    }

    public bool IsPotPoisoned()
    {
        return _isPoisoned;
    }

    public Item GetItemNeededForCure()
    {
        if (_isPoisoned)
        {
            return _itemNeededForCure;
        }

        return null;
    }
}