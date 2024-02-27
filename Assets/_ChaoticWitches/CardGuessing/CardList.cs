using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCardList", menuName = "ChaoticWitches/CardList", order = 0)]
public class CardList : ScriptableObject
{
    public Card[] cards;

    public Card GetRandomCard()
    {
        Card randomCard = cards[Random.Range(0, cards.Length)];
        cards = cards.Where(x => x != randomCard).ToArray();
        return randomCard;
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
}