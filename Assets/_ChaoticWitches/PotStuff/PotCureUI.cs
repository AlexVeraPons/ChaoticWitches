using UnityEngine;

public class PotCureUI : MonoBehaviour
{
    [SerializeField] private UIItem itemToUnpoison;
    private TeamManager _teamManager => TeamManager.Instance;
    private void OnEnable()
    {
        PlayingState.OnTurnChanged += OnTurnChanged;
    }
    private void OnTurnChanged(PlayingState.Turn turn)
    {
        if (IsPotPoisoned())
        {
            itemToUnpoison.SetItem(_teamManager.GetCurrentTeam().PotInventory.GetItemNeededForCure());
        }
        else
        {
            itemToUnpoison.ClearItem();
        }
    }

    private bool IsPotPoisoned()
    {
        Debug.Log("Is team manager null " + (_teamManager == null));
        return _teamManager.GetCurrentTeam().PotInventory.IsPotPoisoned();
    }

}