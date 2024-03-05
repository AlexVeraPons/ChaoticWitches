using UnityEngine;
using TMPro;
using System;
public class AmountOfStepsHud : MonoBehaviour
{
    private TextMeshProUGUI _stepsText;
    private int _ammountOfSteps;
    private string _textToShow => ("You have gained: " + _ammountOfSteps + " steps.");

    private void OnEnable()
    {
        StepAmmountCalculator.OnAmmountOfStepsChanged += LogAmmountOfSteps;
    }

    private void OnDisable()
    {
        StepAmmountCalculator.OnAmmountOfStepsChanged -= LogAmmountOfSteps;
    }
    private void Awake()
    {
        _stepsText = GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        _stepsText.text = "";
    }
    private void LogAmmountOfSteps(int obj)
    {
        _ammountOfSteps = obj;
    }

    public void ShowAmmountOfSteps()
    {
        _stepsText.text = _textToShow;

    }
}