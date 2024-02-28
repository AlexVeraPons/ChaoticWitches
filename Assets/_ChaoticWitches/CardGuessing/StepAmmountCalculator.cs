using System;
using UnityEngine;

public class StepAmmountCalculator : MonoBehaviour
{
    public static Action<int> OnAmmountOfStepsInvoked;
    private int _stepAmmount = 0;
    
    private void OnEnable() {
    }

    private void OnDisable() {
    }
    public void AddStep()
    {
        _stepAmmount++;
    }

    public void ResetSteps()
    {
        _stepAmmount = 0;
    }

    public void InvokeAmmountOfSteps()
    {
        OnAmmountOfStepsInvoked?.Invoke(_stepAmmount);
    }
}
