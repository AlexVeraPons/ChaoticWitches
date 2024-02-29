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
            if (state == true)
            {
                _currentCard.state = Card.CardState.Right;
                _stepAmmountCalculator.AddStep();
                return;
            }

            _currentCard.state = Card.CardState.Wrong;
            return;
        }
        else
        {
            Debug.LogError("No card to guess");
        }
    }

    public Card GetNewCard()
    {
        if (_availableCards.Length() > 0)
        {
            _currentCard = _availableCards.GetRandomCard();
            return _currentCard;
        }
        return null;
    }
}
