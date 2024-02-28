using System;
using UnityEngine;

public class GuessingCardsState : GameState
{
    public static Action OnGuessingCardsStateEnter;
    public static Action OnGuessingCardsStateExit;
    [SerializeField] private GameObject _guessingCardsPanel;

    private void Start() {
        _guessingCardsPanel.SetActive(false);
    }


    public void OnTimerEnded()
    {
        gameFlow.SwitchState(gameFlow.BoardState);
    }

    public override void OnEnter()
    {
        OnGuessingCardsStateEnter?.Invoke();
        _guessingCardsPanel.SetActive(true);
    }

    public override void OnExit()
    {
        OnGuessingCardsStateExit?.Invoke();
        _guessingCardsPanel.SetActive(false);
    }
}
