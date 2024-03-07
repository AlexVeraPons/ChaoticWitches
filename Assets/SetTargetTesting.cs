using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetTesting : MonoBehaviour
{
    [SerializeField] private Player1Controller player1;
    [SerializeField] private Player1Controller player2;

    public void SetNewTarget(Transform newTarget)
    {
        if (player1.itIsMyTurn)
        {
            if (player1.canSetNewTarget)
            {
                player1.targetIsSet = true;
                player1.SetTarget(newTarget);

            }
        }
        else if(player2.itIsMyTurn)
        {
            if (player2.canSetNewTarget)
            {
                player2.targetIsSet = true;
                player2.SetTarget(newTarget);

            }
        }
    }
}
