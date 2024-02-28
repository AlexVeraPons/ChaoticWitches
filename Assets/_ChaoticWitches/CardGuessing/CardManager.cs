using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private CardList _originalCards;
    private CardList _availableCards;
    private Card _currentCard;

    [SerializeField] private CardHolder _cardHolder;
    [SerializeField] private StepAmmountCalculator _stepAmmountCalculator;

    private void Start()
    {
        _availableCards = Instantiate(_originalCards);
        _currentCard = _availableCards.GetRandomCard();

        _cardHolder.SetCardManager(this);
        _cardHolder.SetCard(_currentCard);
    }

    public void ResetCards()
    {
        _availableCards = Instantiate(_originalCards);
    }

    public void GuessedCard(bool state)
    {
        if (_currentCard != null)
        {
            _currentCard.state = state ? Card.CardState.Right : Card.CardState.Wrong;
        }
        else
        {
            Debug.LogError("No card to guess");
        }
    }

    public void GetNewCard()
    {
        if (_availableCards.Length() > 0)
        {
            _currentCard = _availableCards.GetRandomCard();
            _cardHolder.SetCard(_currentCard);

            _stepAmmountCalculator.AddStep();
        }
        else
        {
            Debug.LogError("No more cards to guess");
        }
    }
}
