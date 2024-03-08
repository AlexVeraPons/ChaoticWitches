using UnityEngine;

public class DebugPoisonPotOnSpacebar : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TeamManager.Instance.GetNotCurrentTeam().PotInventory.TryPoisionPot(out bool isPoisoned);
            TeamManager.Instance.GetNotCurrentTeam().PotInventory.gameObject.AddComponent<OnPoisoned>().SetTeam(PlayingState.Instance.GetCurrentTurn() == PlayingState.Turn.Team1 ? PlayingState.Turn.Team2 : PlayingState.Turn.Team1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayingState.Instance.ChangeTurn();
        }
    }
}
