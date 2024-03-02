using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHistory : MonoBehaviour
{
    [SerializeField] private List<Card> _cardsInHistory = new List<Card>();

    public void AddCardToHistory(Card card)
    {
        _cardsInHistory.Add(card);
    }

    public Card[,] OrganizeCardsInColumnarGrid(int columnAmmount)
    {
        List<Card> flippedCardsList = new List<Card>(_cardsInHistory);
        flippedCardsList.Reverse();

        float rows = Mathf.Ceil((float)flippedCardsList.Count / (float)columnAmmount);

        Card[,] cards = new Card[(int)rows, columnAmmount];
        
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columnAmmount; j++)
            {
                if(i * columnAmmount + j >= flippedCardsList.Count)
                {
                    return cards;
                }
                cards[i, j] = flippedCardsList[i * columnAmmount + j];
            }
        }

        return cards;
    }

    public void ClearHistory()
    {
        _cardsInHistory.Clear();
    }
}
