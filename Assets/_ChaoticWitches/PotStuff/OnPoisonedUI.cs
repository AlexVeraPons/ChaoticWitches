using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnPoisonedUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    [SerializeField] private GameObject _image;
    private TeamManager _teamManager => TeamManager.Instance;

    private void OnEnable()
    {
        PlayingState.OnTurnChanged += OnTurnChanged;
    }
    private void Awake()
    {
        _text = _image.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnTurnChanged(PlayingState.Turn turn)
    {
        if (IsCurrentTeamPoisoned())
        {
            _image.SetActive(true);
            int turnsRemaining = _teamManager.GetCurrentTeam().PotInventory.gameObject.GetComponent<OnPoisoned>().TurnsRemaining();

            if (turnsRemaining == 0)
            {
                _text.text = "";
            }
            else
            {
                _text.text = turnsRemaining.ToString();
            }
        }
        else
        {
            _image.SetActive(false);
            _text.text = "";
        }
    }

    private bool IsCurrentTeamPoisoned()
    {
        return _teamManager.GetCurrentTeam().PotInventory.IsPotPoisoned();
    }
}