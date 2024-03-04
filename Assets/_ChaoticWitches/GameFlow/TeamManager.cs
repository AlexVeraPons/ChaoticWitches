using UnityEngine;

public class TeamManager : MonoBehaviour {
    [SerializeField] private Team team1;
    [SerializeField] private Team team2;

    [SerializeField] private PlayingState _playingState;

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

    public Team GetTeam1()
    {
        return team1;
    }

    public Team GetTeam2()
    {
        return team2;
    }
}