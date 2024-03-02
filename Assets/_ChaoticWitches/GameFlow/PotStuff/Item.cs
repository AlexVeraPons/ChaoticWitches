using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DefaultItemName", menuName = "ChaoticWitches/item", order = 0)]
public class Item : ScriptableObject, ICanBeGathered
{
    public Image image;
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
        _itemStatus = ItemStatus.Gathered;
    }

    public Item GetItem()
    {
        return this;
    }
}

