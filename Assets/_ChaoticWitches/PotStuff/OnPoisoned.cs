using System;
using UnityEngine;

public class OnPoisoned : MonoBehaviour {
    public Action<int> OnPoisonedItemTurnChanged;
    private int _turnsSinceComponentAdded = 0;
    private int _turnsToDie = 4; 
    private PlayingState.Turn _team;
    private void OnEnable() {
        PlayingState.OnTurnChanged += OnTurnChanged;
    }

    public void SetTeam(PlayingState.Turn team) {
        _team = team;
    }

    private void OnTurnChanged(PlayingState.Turn turn)
    {
        if (turn == _team)
        {
            _turnsSinceComponentAdded++;
            OnPoisonedItemTurnChanged?.Invoke(_turnsToDie-_turnsSinceComponentAdded);
            if (_turnsSinceComponentAdded >= _turnsToDie)
            {
                PlayingState.Instance.Lose(_team);
                _turnsSinceComponentAdded = 0;
                OnPoisonedItemTurnChanged?.Invoke(0);
            }
        }
    }

    public int TurnsRemaining() {
        return _turnsToDie - _turnsSinceComponentAdded;
    }
}