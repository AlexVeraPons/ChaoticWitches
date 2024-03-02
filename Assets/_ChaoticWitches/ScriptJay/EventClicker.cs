using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClicker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Material newMaterial;
    [SerializeField] private Material oldMaterial;
    [SerializeField] private Material testMaterial;

    [SerializeField] private Player1Controller player1;
    [SerializeField] private Player1Controller player2;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<Player1Controller>();
        player2 = GameObject.Find("Player2").GetComponent<Player1Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.GetComponent<MeshRenderer>().material.name == "TilesPlayer1 (Instance)")
        {
            Debug.Log(" i have the same color");
            player1.SetNewTarget(gameObject.transform);
        }

        if(gameObject.GetComponent<MeshRenderer>().material.name == "TilesPlayer2 (Instance)")
        {
            player2.SetNewTarget(gameObject.transform);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponent<MeshRenderer>().material = testMaterial;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
