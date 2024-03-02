using UnityEngine;
using StateMachine;

public class GameStateMachine : BaseStateMachine
{
    private void Awake()
    {
    }

    public override void SwitchState<GameState>(GameState state)
    {
        base.SwitchState(state);
    }
}
