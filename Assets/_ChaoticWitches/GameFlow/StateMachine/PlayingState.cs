using System;
using UnityEngine;

public class PlayingState : GameState {
    #region Singleton
    public static PlayingState Instance { get; private set; }
    
    void Awake()
    {
        transform.parent = null;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    #endregion
    
    
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
            Lose(_currentTurn);
        }
    }

    public void Lose(Turn turn)
    {
            if(stateMachine == null)
            {stateMachine = this.GetComponent<GameStateMachine>();}
        if (turn == Turn.Team1)
        {
            stateMachine.SetWinner(Turn.Team2);
            stateMachine.SwitchState(stateMachine.EndGameState);
        }
        else
        {
            stateMachine.SetWinner(Turn.Team1);
            stateMachine.SwitchState(stateMachine.EndGameState);
        }
    }
}