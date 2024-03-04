using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeamIcons : MonoBehaviour
{
    public Image image;
    public TMP_Text title;
    public Toggle[] togglesIco;
    [HideInInspector]public bool isActive = false;

    public void FillInfo()
    {
        for (int i = 0; i < togglesIco.Length; i++)
        {
            if(togglesIco[i].isOn)
            {
                image.sprite = togglesIco[i].GetComponent<TeamInfo>().spriteIco;
                title.text = togglesIco[i].GetComponent<TeamInfo>().title;
                isActive = true;
                togglesIco[i].gameObject.SetActive(false);
                togglesIco[i].isOn = false;
                if(i < togglesIco.Length-1)
                {
                    if(togglesIco[i + 1].gameObject.active)
                    togglesIco[i + 1].isOn= true;
                }
                else
                {
                    if (togglesIco[i - 1].gameObject.active)
                        togglesIco[i - 1].isOn = true;
                }
                break;
            }
        }
    }

    public void IsActive(bool active)
    {
        isActive = active;
    }
}
