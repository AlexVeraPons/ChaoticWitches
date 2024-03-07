using UnityEngine;

public class SetPlayerSteps : MonoBehaviour {
    private Player1Controller _player1Controller;

    private void OnEnable() {
        StepAmmountCalculator.OnAmmountOfStepsInvoked += SetSteps;
    }

    private void SetSteps(int ammount)
    {
        if (_player1Controller.itIsMyTurn == false) return;
        
        _player1Controller.SetSteps(ammount);

        Debug.Log(this.name + " steps: " + ammount);
    }

    private void Awake() {
        _player1Controller = GetComponent<Player1Controller>();
    }
}