using UnityEngine;

public class SingletoneCaller : MonoBehaviour {
    public void AllItemsGathered()
    {
        TeamManager.Instance.GetCurrentTeam().PotInventory.CheckIfAllItemsGathered();
    }
}