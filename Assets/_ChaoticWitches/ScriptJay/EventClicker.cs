using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClicker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Player1Controller player1;
    [SerializeField] private Player1Controller player2;

    [SerializeField] private MovementTest movementTestPlayer1;

    [SerializeField] private PathFinder pathPlayer1;
    [SerializeField] private PathFinder pathPlayer2;

    // Start is called before the first frame update
    void Awake()
    {
        player1 = GameObject.Find("Player1").GetComponent<Player1Controller>();
        player2 = GameObject.Find("Player2").GetComponent<Player1Controller>();

        pathPlayer1 = GameObject.Find("Player1").GetComponent<PathFinder>();
        pathPlayer2 = GameObject.Find("Player2").GetComponent<PathFinder>();


        movementTestPlayer1 = GameObject.Find("Player1").GetComponent<MovementTest>();

        movementTestPlayer1.hasPressed = false;
    }

    private void FixedUpdate()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.GetComponent<MeshRenderer>().material.name == "TilesPlayer1 (Instance)")
        {
            player1.destination = gameObject.transform;
            if(!player1.hasPressed)
            {
                player1.FillInBetweenList();
                player1.SetNextTargetInList();
            }
        }

        if(gameObject.GetComponent<MeshRenderer>().material.name == "TilesPlayer2 (Instance)")
        {
            player2.destination = gameObject.transform;
            if (!player2.hasPressed)
            {
                player2.FillInBetweenList();
                player2.SetNextTargetInList();
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
