using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [SerializeField] private Player1Controller player1;
    [SerializeField] private Player1Controller player2;

    private void Awake()
    {
        player1 = GameObject.Find("Player1").GetComponent<Player1Controller>();
        player2 = GameObject.Find("Player2").GetComponent<Player1Controller>();
    }

    public void SwitchPlayers()
    {
        player1.SetNewTarget(player2.swapLocation);
        player2.SetNewTarget(player1.swapLocation);
        player1.haveSwapped = true;
        player2.haveSwapped = true;
    }

    public void SwitchRandomItems()
    {

    }


}
