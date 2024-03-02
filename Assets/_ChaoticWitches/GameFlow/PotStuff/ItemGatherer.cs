using UnityEngine;

[RequireComponent(typeof(Team))]
[RequireComponent(typeof(Collider))]
public class ItemGatherer : MonoBehaviour
{
    [SerializeField] private Team _team;
    private PotInventory _potInventory;
    private void Start()
    {
        _potInventory = _team.PotInventory;
    }

    private void OnTriggerEnter(Collider other)
    {
        ICanBeGathered item = other.GetComponent<ICanBeGathered>();
        if (item != null && !item.IsGathered())
        {
            item.Gather();
            _potInventory.TryGatherItem(item.GetItem());
        }
    }
}