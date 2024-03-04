using StateMachine;
using UnityEngine;

[RequireComponent(typeof(GameStateMachine))]
public class GameState : BaseState
{
    protected GameStateMachine stateMachine;
    private void Awake()
    {
        stateMachine = GetComponent<GameStateMachine>();
    }
}
