using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCardList", menuName = "ChaoticWitches/CardList", order = 0)]
public class CardList : ScriptableObject
{
    public List<Card> cards = new List<Card>();

    public Card GetRandomCard()
    {
        Card randomCard = cards[Random.Range(0, cards.Count)];
        return randomCard;
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public int Length()
    {
        return cards.Count;
    }
}

[System.Serializable]
public class Card
{
    public string name;
    
    [HideInInspector]
    public enum CardState
    {
        NotGuessed,
        Right,
        Wrong
    }

    [HideInInspector]
    public CardState state = CardState.NotGuessed;

    public Card(string name)
    {
        this.name = name;
        state = CardState.NotGuessed;
    }
}