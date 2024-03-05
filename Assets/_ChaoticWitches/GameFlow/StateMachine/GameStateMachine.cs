using UnityEngine;
using StateMachine;

[RequireComponent(typeof(PlayingState))]
[RequireComponent(typeof(StateStart))]
public class GameStateMachine : BaseStateMachine
{
    [HideInInspector] public PlayingState PlayingState;
    [HideInInspector] public StateStart StartsState;

    private void Awake()
    {
        PlayingState = GetComponent<PlayingState>();
        StartsState = GetComponent<StateStart>();
    }

    private void Start() {
        SwitchState(StartsState);
    }

    public override void SwitchState<GameState>(GameState state)
    {
        base.SwitchState(state);
    }
}
