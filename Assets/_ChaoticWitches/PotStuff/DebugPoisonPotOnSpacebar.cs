using UnityEngine;

public class DebugPoisonPotOnSpacebar : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TeamManager.Instance.GetNotCurrentTeam().PotInventory.TryPoisionPot(out bool isPoisoned);
        }
    }
}
