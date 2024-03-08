using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameState : GameState {
    [SerializeField] private TextMeshProUGUI _winnerText;
    [SerializeField] private TextMeshProUGUI _loserText;
    [SerializeField] private GameObject _endGamePanel; 
    [SerializeField] private List<GameObject> _thingsToDisable = new List<GameObject>();
    public override void OnEnter()
    {
        base.OnEnter();
        _endGamePanel.SetActive(true);
        _winnerText.text = stateMachine.Winner.ToString();
        _loserText.text = (stateMachine.Winner == PlayingState.Turn.Team1 ? PlayingState.Turn.Team2 : PlayingState.Turn.Team1).ToString();
        foreach (GameObject thing in _thingsToDisable)
        {
            thing.SetActive(false);
        }
    }
    
}