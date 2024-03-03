using System;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Color _notGatheredColor;
    private Color _gatheredColor = Color.white;
    public Action OnItemClicked;
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
        
        _image.sprite = item.GetSprite();

        _image.color = item.IsGathered() ? _gatheredColor : _notGatheredColor;
    }

    private void OnItemGathered()
    {
        Debug.Log("Item gathered!");
        _image.color = _gatheredColor;
    }

    public void OnClick()
    {
        OnItemClicked?.Invoke();
    }
}