using System.Collections;
using UnityEngine;

public class StateStart : GameState
{
    private const int _delayBeforeStateChange = 3;
    public override void OnEnter()
    {
        base.OnEnter();
        StartCoroutine(ChangeStateToPlayState());

        Debug.Log("Text");
    }

    private IEnumerator ChangeStateToPlayState()
    {
        yield return new WaitForSeconds(_delayBeforeStateChange);
        stateMachine.SwitchState(stateMachine.PlayingState);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
