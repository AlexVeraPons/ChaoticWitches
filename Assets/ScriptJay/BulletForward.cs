using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForward : MonoBehaviour
{
    [SerializeField] private LayerMask Walls;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private Object LeftPrefab;
    [SerializeField] private Object RightPrefab;

    private bool hasHitLeftWall = false;
    private bool hasHitRightWall = false;

    private void Update()
    {
        MoveForward();
        CheckWallLeft();
        CheckWallRight();
    }

    private void MoveForward()
    {
        rb.AddForce(Vector3.forward * 0.2f);
    }

    private void CheckWallLeft()
    {
        if(Physics.Raycast(transform.position, Vector3.left, out RaycastHit hitInfo, 1.2f, Walls))
        {
            hasHitLeftWall = true;
            Debug.Log(hasHitLeftWall);

        } else if(hasHitLeftWall)
        {
            Instantiate(LeftPrefab, position: transform.position, rotation: Quaternion.Euler(0,0,0));
            hasHitLeftWall = false;
        }
    }

    private void CheckWallRight()
    {
        if (Physics.Raycast(transform.position, Vector3.right, out RaycastHit hitInfo, 1.2f, Walls))
        {
            hasHitRightWall = true;
        }
        else if (hasHitRightWall)
        {
            Instantiate(RightPrefab, position: transform.position, rotation: Quaternion.Euler(0, 0, 0));
            hasHitRightWall= false;
        }
    }
}
