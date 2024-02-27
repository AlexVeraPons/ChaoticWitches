using System;
using UnityEngine;

public class GuessingCardsState : GameState
{
    public static Action OnGuessingCardsStateEnter;
    public static Action OnGuessingCardsStateExit;
    public void OnTimerEnded()
    {
        gameFlow.SwitchState(gameFlow.BoardState);
    }

    public override void OnEnter()
    {
        OnGuessingCardsStateEnter?.Invoke();
    }

    public override void OnExit()
    {
        OnGuessingCardsStateExit?.Invoke();
    }
}
