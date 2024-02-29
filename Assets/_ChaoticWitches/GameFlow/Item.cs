using UnityEngine;

public class Item : ICanBeGathered
{
    private Sprite _itemImage;
    enum ItemStatus
    {
        Gathered,
        NotGathered
    }
    private ItemStatus _itemStatus;

    public bool IsGathered()
    {
        return _itemStatus == ItemStatus.Gathered;
    }

    public void Gather()
    {
        _itemStatus = ItemStatus.Gathered;
    }
}

