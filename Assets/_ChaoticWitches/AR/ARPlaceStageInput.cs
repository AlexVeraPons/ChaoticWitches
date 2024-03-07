using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class ARPlaceStageInput : SmartTerrainBehaviour
{
    [System.Serializable]
    public class InputReceivedEvent : UnityEvent<Vector2> { }
    public InputReceivedEvent OnInputReceivedEvent;
    public void ConfirmStagePosition()
    {
        Vector2 screenPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        OnInputReceivedEvent?.Invoke(screenPosition);
    }
}