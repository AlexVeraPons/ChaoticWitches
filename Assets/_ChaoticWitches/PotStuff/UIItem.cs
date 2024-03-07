using System;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public static Action<ItemLocation> OnItemClicked;
    [SerializeField] private bool _changesColor = true;
    public Action<Transform> OnItemClickedNode;
    [SerializeField] private Color _notGatheredColor;
    private Color _gatheredColor = Color.white;
    [SerializeField] private Item _item;
    private Image _image;
    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.color.a.Equals(0);
    }

    private void Start()
    {
        if (_item != null)
        {
            SetItem(_item);
        }
    }

    public void SetItem(Item item)
    {
        _item = item;
        _item.OnGathered += OnItemGathered;

        _image.sprite = item.GetSprite();

        if (_changesColor)
        {
            _image.color = item.IsGathered() ? _gatheredColor : _notGatheredColor;
        }
        else
        {
            _image.color = Color.white;
        }
    }

    private void OnItemGathered()
    {
        _image.color = _gatheredColor;
    }

    public void OnClick()
    {
        ItemLocation itemLocation = LocationOfItemsManager.Instance.GetItemLocation(_item);
        OnItemClicked?.Invoke(itemLocation);
    }

    public void ClearItem()
    {
        _item = null;
        _image.sprite = null;
        _image.color = _notGatheredColor;

        if (_item != null) { _item.OnGathered -= OnItemGathered; }
    }
    

    public Item GetItem()
    {
        return _item;
    }
}