using System;
using System.Collections.Generic;
using UnityEngine;

public class UIChangesForTeams : MonoBehaviour
{
    [SerializeField] private List<GameObject> _team1UIElements;
    [SerializeField] private List<GameObject> _team2UIElements;

    private void OnEnable()
    {
        PlayingState.OnTurnChanged += OnTurnChanged;
    }

    private void OnTurnChanged(PlayingState.Turn turn)
    {
        if (turn == PlayingState.Turn.Team1)
        {
            SetActive(_team1UIElements, true);
            SetActive(_team2UIElements, false);
        }
        else
        {
            SetActive(_team1UIElements, false);
            SetActive(_team2UIElements, true);
        }
    }

    private void SetActive(List<GameObject> team1UIElements, bool value)
    {
        foreach (GameObject item in team1UIElements)
        {
            item.SetActive(value);
        }
    }
}