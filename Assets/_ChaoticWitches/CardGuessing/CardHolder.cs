using TMPro;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    const string stringBeforeName = "Your word is:";
     private Card _card;
    [SerializeField] private TextMeshProUGUI _cardName;
    CardManager _cardManager;

    public void SetCard(Card card)
    {
        _cardName.text =  stringBeforeName + card.name;
        _card = card;
    }

    public void SetCardManager(CardManager cardManager)
    {
        _cardManager = cardManager;
    }

    public void GuessRight()
    {
        _cardManager.GuessedCard(true);
        SetCard(_cardManager.GetNewCard());
    }

    public void GuessWrong()
    {
        _cardManager.GuessedCard(false);
        SetCard(_cardManager.GetNewCard());
    }

    public void NewCard()
    {
        SetCard(_cardManager.GetNewCard());
    }

}
