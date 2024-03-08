using UnityEngine;

public class PoisonedItemObject : MonoBehaviour {
    private PotInventory _currentPot => TeamManager.Instance.GetNotCurrentTeam().PotInventory;

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Player1Controller>()) {
            _currentPot.TryPoisionPot(out bool isPoisoned);
            
            OnPoisoned poisoned = _currentPot.gameObject.AddComponent<OnPoisoned>();
            PlayingState.Turn team = PlayingState.Instance.GetCurrentTurn() == PlayingState.Turn.Team1 ? PlayingState.Turn.Team2 : PlayingState.Turn.Team1;
            poisoned.SetTeam(team);
            
            if (isPoisoned)
            {
                Destroy(gameObject);
            }
        }
    }

}