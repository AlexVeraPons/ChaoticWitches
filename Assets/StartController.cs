using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StartController : MonoBehaviour
{
    [Header("Start")]
    public UnityEvent startGame;
   
    public TeamIcons firstTeam;
    public TeamIcons secondTeam;

    [Header("Restart")]
    public Toggle[] togglesTeam;
    public UnityEvent restartGame;

    public void StartGame()
    {
        if(firstTeam.isActive && secondTeam.isActive)
            startGame.Invoke();
    }
    
    public void ResetGame()
    {
        for (int i = 0; i < togglesTeam.Length; i++)
        {
            togglesTeam[i].gameObject.SetActive(true);
        }
        togglesTeam[0].isOn = true;
        restartGame.Invoke();
    }

}
