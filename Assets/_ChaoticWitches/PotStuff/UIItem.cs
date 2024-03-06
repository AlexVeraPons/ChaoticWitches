using System;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Action OnItemClicked;
    public Action<Transform> OnItemClickedNode;

    [SerializeField] private Color _notGatheredColor;
    private Color _gatheredColor = Color.white;
    private   Item _item;
    private Image _image;
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void SetItem(Item item)
    {
        _item = item;
        _item.OnGathered += OnItemGathered;

        Debug.Log("item name is " + item.name);
        
        Debug.Log("sprite name is " + item.GetSprite().name);
        _image.sprite = item.GetSprite();

        _image.color = item.IsGathered() ? _gatheredColor : _notGatheredColor;
    }

    private void OnItemGathered()
    {
        _image.color = _gatheredColor;
    }

    public void OnClick()
    {
        OnItemClicked?.Invoke();

        Transform transformOfItem = LocationOfItemsManager.Instance.GetLocationOfItem(_item);
        OnItemClickedNode?.Invoke(transformOfItem);
    }

    public void ClearItem()
    {
        _item.OnGathered -= OnItemGathered;
        _item = null;
        _image.sprite = null;
        _image.color = _notGatheredColor;
    }
}