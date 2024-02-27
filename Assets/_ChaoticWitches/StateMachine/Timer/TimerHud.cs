using TMPro;
using UnityEngine;
public class TimerHud : MonoBehaviour
{
    private TextMeshProUGUI _timerText;
    private IgiveTime _time;
    private void Awake()
    {
        _time = GetComponent<IgiveTime>();
        _timerText = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        _time = GetComponent<IgiveTime>();
        _time.MaxTime();
    }
    private void Update()
    {
        _timerText.text = _time.CurrentTime().ToString();
    }
}
