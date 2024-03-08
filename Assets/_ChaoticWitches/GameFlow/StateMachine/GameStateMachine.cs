using UnityEngine;
using StateMachine;

[RequireComponent(typeof(PlayingState))]
[RequireComponent(typeof(StateStart))]
[RequireComponent(typeof(EndGameState))]
public class GameStateMachine : BaseStateMachine
{
    [HideInInspector] public PlayingState PlayingState;
    [HideInInspector] public StateStart StartsState;
    [HideInInspector] public EndGameState EndGameState;

    private PlayingState.Turn _winner;
    public  PlayingState.Turn Winner => _winner;
    private void Awake()
    {
        PlayingState = GetComponent<PlayingState>();
        StartsState = GetComponent<StateStart>();
        EndGameState = GetComponent<EndGameState>();
    }

    private void Start() {
        SwitchState(StartsState);
    }

    public override void SwitchState<GameState>(GameState state)
    {
        base.SwitchState(state);
    }

    public void SetWinner(PlayingState.Turn winner)
    {
        _winner = winner;
    }
}
