using UnityEngine;

public class PoisonedItemObject : MonoBehaviour {
    private PotInventory _currentPot => TeamManager.Instance.GetNotCurrentTeam().PotInventory;

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Player1Controller>()) {
            _currentPot.TryPoisionPot(out bool isPoisoned);
            
            if (isPoisoned)
            {
                Destroy(gameObject);
            }
        }
    }

}