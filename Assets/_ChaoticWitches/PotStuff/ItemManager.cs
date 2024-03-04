using UnityEngine;

public class ItemManager : MonoBehaviour, ICanBeGathered {
    [SerializeField] private Item _item;

    public void Gather()
    {
        _item.Gather();
    }

    public bool IsGathered()
    {
        return _item.IsGathered();
    }

    public Item GetItem()
    {
        return _item;
    }
}