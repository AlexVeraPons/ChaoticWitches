using System;
using UnityEngine;

public class PlayingState : GameState {
    public static Action<Turn> OnTurnChanged;
    public static Action OnEnterState;
    public enum Turn
    {
        Team1,
        Team2
    }

    private Turn _currentTurn;
    public void OnEnable() {
      Player1Controller.OnTurnEnded += ChangeTurn;
    }

    public void Start()
    {
        _currentTurn = Turn.Team1;
    }
    public Turn GetCurrentTurn()
    {
        return _currentTurn;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        OnEnterState?.Invoke();
    }
    public void ChangeTurn()
    {
        if (_currentTurn == Turn.Team1)
        {
            _currentTurn = Turn.Team2;
        }
        else
        {
            _currentTurn = Turn.Team1;
        }
        OnTurnChanged?.Invoke(_currentTurn);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeTurn();
        }
    }
}