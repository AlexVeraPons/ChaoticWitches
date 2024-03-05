using TMPro;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    const string stringBeforeName = ""; // in case we want to add something before the card name
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
        NewCard();
    }

    public void GuessWrong()
    {
        _cardManager.GuessedCard(false);
        NewCard();
    }

    public void NewCard()
    {
        SetCard(_cardManager.GetNewCard());
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GuessRight();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            GuessWrong();
        }
    }
}
