using UnityEngine;
using StateMachine;

[RequireComponent(typeof(GuessingCardsState))]
[RequireComponent(typeof(BoardState))]
public class GameFlow : BaseStateMachine
{
    [HideInInspector]public GameState GuessingCardsState;
    [HideInInspector]public GameState BoardState;

    private void Awake()
    {
        GuessingCardsState = GetComponent<GuessingCardsState>();
        BoardState = GetComponent<BoardState>();
    }

    public override void SwitchState<GameState>(GameState state)
    {
        base.SwitchState(state);
    }
}
