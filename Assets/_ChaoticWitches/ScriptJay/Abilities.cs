using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [SerializeField] private Player1Controller player1;
    [SerializeField] private Player1Controller player2;

    private bool player1HasUsedTeleport = false;
    private bool player2HasUsedTeleport = false;

    private bool player1HasUsedStepMult = false;
    private bool player2HasUsedStepMult = false;

    private void Awake()
    {
        player1 = GameObject.Find("Player1").GetComponent<Player1Controller>();
        player2 = GameObject.Find("Player2").GetComponent<Player1Controller>();
    }

    public void SwitchPlayers()
    {
        if(player1.itIsMyTurn)
        {
            if (!player1HasUsedTeleport)
            {
                player1.gameObject.transform.position = Vector3.Lerp(player1.transform.position, player2.swapLocation.position, 1);
                player1.haveSwapped = true;
                player2.gameObject.transform.position = Vector3.Lerp(player2.transform.position, player1.swapLocation.position, 1);
                player2.haveSwapped = true;
            }
            player1HasUsedTeleport = true;
        } else
        {
            if (!player2HasUsedTeleport)
            {
                player1.gameObject.transform.position = Vector3.Lerp(player1.transform.position, player2.swapLocation.position, 1);
                player1.haveSwapped = true;
                player2.gameObject.transform.position = Vector3.Lerp(player2.transform.position, player1.swapLocation.position, 1);
                player2.haveSwapped = true;
            }
            player1HasUsedTeleport = true;
        }
    }

    public void MultiplySteps()
    {
        if (player1.itIsMyTurn)
        {
            if(!player1HasUsedStepMult)
            {

            }
        } else
        {
            if (!player2HasUsedStepMult)
            {

            }
        }
    }


}
