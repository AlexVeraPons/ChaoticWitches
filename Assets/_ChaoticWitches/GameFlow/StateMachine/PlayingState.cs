using System;
using UnityEngine;

public class PlayingState : GameState {
    public static Action<Turn> OnTurnChanged;
    public enum Turn
    {
        Team1,
        Team2
    }

    private Turn _currentTurn;

    public void Start()
    {
        _currentTurn = Turn.Team1;
    }
    public Turn GetCurrentTurn()
    {
        return _currentTurn;
    }
}