using UnityEngine;

public class ItemInitializerUI : MonoBehaviour
{
    [SerializeField] private GameObject _UIitemPrefab;
    [SerializeField] private GameObject _gameObjectContainer; 
    [SerializeField] private GameObject _itemToIgnore;

    private PotInventory _currentPotInventory => TeamManager.Instance.GetCurrentTeam().PotInventory;

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
        foreach (Transform child in _gameObjectContainer.transform)
        {
            if (child.gameObject == _itemToIgnore) continue;
            Destroy(child.gameObject);
        }

        Item[] items = _currentPotInventory.GetNeededItems();

        foreach (Item item in items)
        {
            GameObject UIitem = Instantiate(_UIitemPrefab, _gameObjectContainer.transform);
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