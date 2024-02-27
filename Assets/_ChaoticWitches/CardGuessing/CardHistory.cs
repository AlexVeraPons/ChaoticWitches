using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHistory : MonoBehaviour
{
    [SerializeField] GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private GameObject _cardInHistoryPrefab;
    List<GameObject> _cardsInHistory = new List<GameObject>();

    public void AddCardToHistory(Card card)
    {
        GameObject cardInHistory = Instantiate(_cardInHistoryPrefab, _gridLayoutGroup.transform);
        cardInHistory.GetComponentInChildren<Text>().text = card.name;
        _cardsInHistory.Add(cardInHistory);
    }
}
