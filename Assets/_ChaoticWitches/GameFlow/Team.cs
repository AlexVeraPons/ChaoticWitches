using System;
using UnityEngine;

public class Team : MonoBehaviour
{
    public Action FinishedTurn;
    
    [SerializeField] private PotInventory _potInventory;
    public PotInventory PotInventory { get { return _potInventory; } }

    [SerializeField] private Player1Controller _player1Controller;     
    public Player1Controller Player1Controller { get { return _player1Controller; } }
}
