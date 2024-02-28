using UnityEngine;

public class GuessingButton : MonoBehaviour,
{
    [SerializeField] private GameObject _cardCanvas;

    private void Start()
    {
        _cardCanvas.SetActive(false);
    }

    public void OnGuessingButtonClicked()
    {
        _cardCanvas.SetActive(true);
    }
}