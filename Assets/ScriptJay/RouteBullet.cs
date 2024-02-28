using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class RouteBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private Object routeBulletPrefab;

    private bool hasTouchedWall = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(hasTouchedWall)
        {
            MoveRight();
        } else
        {
            MoveForward();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            hasTouchedWall = true;
            //Instantiate(routeBulletPrefab, position: transform.position, rotation: Quaternion.Euler(0, 0.707f, 0));
        }

    }

    private void MoveForward()
    {
        rb.AddForce(Vector3.forward * 2);
    }

    private void MoveRight()
    {
        rb.AddForce(Vector3.right * 2);
    }

    private void MoveLeft()
    {
        rb.AddForce(Vector3.left * 2);
    }

    private void MoveDown()
    {
        rb.AddForce(Vector3.back * 2);
    }
}
