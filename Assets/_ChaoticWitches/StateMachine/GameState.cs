using StateMachine;
using UnityEngine;

[RequireComponent(typeof(GameFlow))]
public class GameState : BaseState
{
    protected GameFlow gameFlow;

    private void Awake()
    {
        gameFlow = GetComponent<GameFlow>();
    }

    public void StartGuessingCardsState()
    {
        gameFlow.SwitchState(gameFlow.GuessingCardsState);
    }
}
