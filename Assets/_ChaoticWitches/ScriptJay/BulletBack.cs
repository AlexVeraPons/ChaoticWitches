using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBack : MonoBehaviour
{
    [SerializeField] private LayerMask Walls;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private Object LeftPrefab;
    [SerializeField] private Object RightPrefab;

    private bool hasHitLeftWall = false;
    private bool hasHitRightWall = false;

    private void Update()
    {
        MoveBack();
        CheckWallLeft();
        CheckWallRight();
    }

    private void MoveBack()
    {
        rb.AddForce(Vector3.back * 0.2f);
    }

    private void CheckWallLeft()
    {
        if (Physics.Raycast(transform.position, Vector3.left, out RaycastHit hitInfo, 2f, Walls))
        {
            hasHitLeftWall = true;
        }
        else if (hasHitLeftWall)
        {
            Instantiate(LeftPrefab, position: transform.position, rotation: Quaternion.Euler(0, 0, 0));
            hasHitLeftWall = false;
        }
    }

    private void CheckWallRight()
    {
        if (Physics.Raycast(transform.position, Vector3.right, out RaycastHit hitInfo, 2f, Walls))
        {
            hasHitRightWall = true;
        }
        else if (hasHitRightWall)
        {
            Instantiate(RightPrefab, position: transform.position, rotation: Quaternion.Euler(0, 0, 0));
            hasHitRightWall = false;
        }
    }
}
