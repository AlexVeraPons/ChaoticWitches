using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class GuessingTimer : MonoBehaviour, IgiveTime
{
    [SerializeField] private float _maxTime = 20f;
    private float _currentTime = 0f;

    public UnityEvent OnGuessingTimerEnd; 

    public void StartTimer()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        _currentTime = _maxTime;
        while (_currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            _currentTime--;
        }
        OnGuessingTimerEnd?.Invoke();
    }

    public float SetMaxTime(float time)
    {
        return _maxTime = time;
    }

    public float MaxTime()
    {
        return _maxTime;
    }

    public float TimeLeft()
    {
        return _currentTime - _maxTime;
    }

    public float CurrentTime()
    {
        return _currentTime;
    }
}
