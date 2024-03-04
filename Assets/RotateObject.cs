using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 direction =Vector3.up;
    void FixedUpdate()
    {
        transform.Rotate(direction);
    }
}
