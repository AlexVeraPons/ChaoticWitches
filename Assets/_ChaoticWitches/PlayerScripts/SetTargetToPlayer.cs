using System;
using UnityEngine;

public class SetTargetToPlayer : MonoBehaviour {
    private Player1Controller _player1Controller;

    private void OnEnable() {
        UIItem.OnItemClicked += SetTarget;
    }

    private void SetTarget(ItemLocation location)
    {
        if (_player1Controller.itIsMyTurn == false) return;
        Debug.Log("Setting target" + this.name + " " + location.location);
        _player1Controller.SetTarget(location.location);
    }

    private void Awake() {
        _player1Controller = GetComponent<Player1Controller>();
    }


}