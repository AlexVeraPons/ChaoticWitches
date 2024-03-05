using UnityEngine;

public class ItemInitializerUI : MonoBehaviour
{
    [SerializeField] private TeamManager _teamManager;
    [SerializeField] private GameObject _UIitemPrefab;

    private PotInventory _currentPotInventory => _teamManager.GetCurrentTeam().PotInventory;

    private void OnEnable()
    {
        PlayingState.OnEnterState += ReInitializeItems;
        PlayingState.OnTurnChanged += OnTurnChanged;
    }

    private void OnDisable()
    {
        PlayingState.OnEnterState -= ReInitializeItems;
        PlayingState.OnTurnChanged -= OnTurnChanged;
    }

    private void Start() {
    }

    private void OnTurnChanged(PlayingState.Turn turn)
    {
        ReInitializeItems();
    }

    public void ReInitializeItems()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Item[] items = _currentPotInventory.GetNeededItems();
        Debug.Log("item ammount is " + items.Length);

        foreach (Item item in items)
        {
            Debug.Log("Item is " + item.ToString());
            GameObject UIitem = Instantiate(_UIitemPrefab, transform);
            UIItem uiItem = UIitem.GetComponent<UIItem>();
            uiItem.SetItem(item);
        }
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReInitializeItems();
        }
    }
}