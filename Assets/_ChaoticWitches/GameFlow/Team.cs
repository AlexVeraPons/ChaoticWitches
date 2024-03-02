using System;
using UnityEngine;

public class Team : MonoBehaviour
{
    public Action FinishedTurn;

    [SerializeField] private PotInventory _potInventory;
    public PotInventory PotInventory { get { return _potInventory; } }
    

}
