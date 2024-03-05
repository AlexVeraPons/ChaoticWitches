using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardHistoryUI : MonoBehaviour
{
    [SerializeField] private int _cardsToShowAtOnce;
    [SerializeField] private GameObject _cardInHistoryPrefab;
    [SerializeField] private CardHistory _cardHistory;
    Card[,] _cardsInHistory;
    private int _currentRow = 0;
    public void ShowCards()
    {
        Debug.Log("Showing cards in history.");
        _cardsInHistory = _cardHistory.OrganizeCardsInColumnarGrid(_cardsToShowAtOnce);

        InstantiateCards();
    }

    private void InstantiateCards()
    {
        for (int j = 0; j < _cardsInHistory.GetLength(1); j++)
        {
            if (_cardsInHistory[_currentRow, j] == null)
            {
                return;
            }

            GameObject instant = Instantiate(_cardInHistoryPrefab, new Vector3(0, 0, 0), Quaternion.identity, transform);

            TextMeshProUGUI text = instant.GetComponentInChildren<TextMeshProUGUI>();
            text.text = _cardsInHistory[_currentRow, j].name;

            Image image = instant.GetComponent<Image>();

            if (_cardsInHistory[_currentRow, j].state == Card.CardState.Right)
            {
                //slightly green
                image.color = new Color(0.5f, 1, 0.5f);
            }
            else
            {
                //slightly red
                image.color = new Color(1, 0.5f, 0.5f);
            }
        }
    }

    public void HideCards()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ShowNextCards()
    {
        if (_currentRow + 1 >= _cardsInHistory.GetLength(0))
        {
            return;
        }        

        _currentRow++;

        HideCards();
        ShowCards();
    }

    public void ShowPreviousCards()
    {
        if (_currentRow - 1 < 0)
        {
            return;
        }

        _currentRow--;

        HideCards();
        ShowCards();

        return;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShowCards();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            HideCards();
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ShowNextCards();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ShowPreviousCards();
        }
    }
}