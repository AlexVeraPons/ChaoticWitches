using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamInfo : MonoBehaviour
{
    [HideInInspector]public Sprite spriteIco;
    public string title;

    void Start()
    {
        spriteIco = transform.GetChild(0).GetComponent<Image>().sprite;
    }
   
}
