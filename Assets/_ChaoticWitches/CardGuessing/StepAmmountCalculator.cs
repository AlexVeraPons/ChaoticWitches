using System;
using UnityEngine;

public class StepAmmountCalculator : MonoBehaviour
{
    public static Action<int> OnAmmountOfStepsInvoked;
    public static Action <int> OnAmmountOfStepsChanged;
    private int _stepAmmount = 0;
    
    public void AddStep()
    {
        _stepAmmount++;
        OnAmmountOfStepsChanged?.Invoke(_stepAmmount);
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
