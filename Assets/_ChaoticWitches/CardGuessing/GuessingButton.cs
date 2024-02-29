using System;
using UnityEngine;

public class GuessingButton : MonoBehaviour
{
    [SerializeField] private GameObject _cardCanvas;
    [SerializeField] private GameObject _otherButton;

    public static Action OnGuessingButtonEnter;
    public static Action OnGuessingButtonExit;

    private void Start()
    {
        _cardCanvas.SetActive(false);
    }

    public void OnGuessingButtonEnterClicked()
    {
        _cardCanvas.SetActive(true);
        OnGuessingButtonEnter?.Invoke();
        this.gameObject.SetActive(false);
    }

    public void OnGuessingButtonExitClicked()
    {
        if (_otherButton != null)
        {
            _otherButton.SetActive(true);
        }
        
        _cardCanvas.SetActive(false);
    }
}