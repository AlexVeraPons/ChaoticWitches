using System;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    [SerializeField] private Team team1;
    [SerializeField] private Team team2;

    [SerializeField] private PlayingState _playingState;

    #region Singleton
    public static TeamManager Instance { get; private set; }
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


    private void OnEnable() {
        PlayingState.OnTurnChanged += OnTurnChanged;
    }

    private void OnTurnChanged(PlayingState.Turn turn)
    {
        GetCurrentTeam().Player1Controller.itIsMyTurn = true;
    }

    public Team GetCurrentTeam()
    {
        if (_playingState.GetCurrentTurn() == PlayingState.Turn.Team1)
        {
            return team1;
        }
        else
        {
            return team2;
        }
    }

    public Team GetNotCurrentTeam()
    {
        if (_playingState.GetCurrentTurn() == PlayingState.Turn.Team1)
        {
            return team2;
        }
        else
        {
            return team1;
        }
    }

    public Team GetTeam1()
    {
        return team1;
    }

    public Team GetTeam2()
    {
        return team2;
    }
}