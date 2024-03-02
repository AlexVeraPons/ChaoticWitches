using System;
using UnityEngine;

public class HideWhileTimerIsOn : MonoBehaviour {
    [SerializeField] private GuessingTimer _guessingTimer;
    private bool _isHidden = false;
    private void Start() {
        _guessingTimer.OnGuessingTimerStart.AddListener(Hide);
        _guessingTimer.OnGuessingTimerEnd.AddListener(Show);
    }

    private void Show()
    {
        _isHidden = false;
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        _isHidden = true;
    }

    private void Update()
    {
        if (_isHidden)
        {
            gameObject.SetActive(false);
        }
    }
}