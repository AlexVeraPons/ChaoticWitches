using System;
using UnityEngine;

public class PoisonedItemUI : MonoBehaviour {
    [SerializeField] private TeamManager _teamManager;
    [SerializeField] private UIItem _uiItem;

    private PotInventory _currentPotInventory => _teamManager.GetCurrentTeam().PotInventory;

    private void OnEnable()
    {
        PlayingState.OnTurnChanged += OnTurnChanged;
    }

    private void OnDisable()
    {
        PlayingState.OnTurnChanged -= OnTurnChanged;
    }

    private void Start() {
    }

    private void OnTurnChanged(PlayingState.Turn turn)
    {
        ReloadPoisonedItem();
    }

    private void ReloadPoisonedItem()
    {
        if(_currentPotInventory.GetItemNeededForCure() != null)
        {
            _uiItem.SetItem(_currentPotInventory.GetItemNeededForCure());
        }
        else
        {
            _uiItem.ClearItem();
        }
    }
}