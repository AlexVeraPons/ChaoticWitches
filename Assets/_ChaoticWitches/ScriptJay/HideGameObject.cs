using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGameObject : MonoBehaviour
{
    public void SetGameObjectToFalse(GameObject wantedGameObject)
    {
        wantedGameObject.SetActive(false);
    }

    public void SetGameObjectToTrue(GameObject wantedGameObject)
    {
        wantedGameObject.SetActive(true);
    }
}
