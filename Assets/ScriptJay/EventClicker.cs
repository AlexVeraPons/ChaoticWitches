using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClicker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Material material;
    public Material newMaterial;
    public Material oldMaterial;
    public MoveToTarget moveToTarget;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.GetComponent<MeshRenderer>().material = newMaterial;
        moveToTarget.NextTarget(transform);

        //PathFinder.instance.FindShortestPath()
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.GetComponent<MeshRenderer>().material = oldMaterial;
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
