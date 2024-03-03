using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DefaultItemName", menuName = "ChaoticWitches/item", order = 0)]
public class Item : ScriptableObject, ICanBeGathered
{
    public Action OnGathered;
    public Sprite sprite;
    enum ItemStatus
    {
        Gathered,
        NotGathered
    }
    [SerializeField] private ItemStatus _itemStatus = ItemStatus.NotGathered;

    public bool IsGathered()
    {
        return _itemStatus == ItemStatus.Gathered;
    }

    public void Gather()
    {
        Debug.Log("I have been gathered!" + name);
        _itemStatus = ItemStatus.Gathered;
        OnGathered?.Invoke();
    }

    public Item GetItem()
    {
        return this;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public void UnGather()
    {
        _itemStatus = ItemStatus.NotGathered;
    }   
}

