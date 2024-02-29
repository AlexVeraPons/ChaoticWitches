using UnityEngine;

public class BulletLeft : MonoBehaviour
{
    [SerializeField] private LayerMask Walls;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private Object ForwardPrefab;
    [SerializeField] private Object BackPrefab;

    private bool hasHitFrontWall = false;
    private bool hasHitBackWall = false;

    private void Update()
    {
        MoveLeft();
        CheckWallFront();
        CheckWallBack();
    }

    private void MoveLeft()
    {
        rb.AddForce(Vector3.left * 0.2f);
    }

    private void CheckWallFront()
    {
        if(Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hitInfo, 1.2f, Walls))
        {
            hasHitFrontWall = true;
        } else if(hasHitFrontWall)
        {
            Instantiate(ForwardPrefab, position: transform.position, rotation: Quaternion.Euler(0,0,0));
            hasHitFrontWall = false;
        }
    }

    private void CheckWallBack()
    {
        if (Physics.Raycast(transform.position, Vector3.back, out RaycastHit hitInfo, 1.2f, Walls))
        {
            hasHitBackWall = true;
        }
        else if (hasHitBackWall)
        {
            Instantiate(BackPrefab, position: transform.position, rotation: Quaternion.Euler(0, 0, 0));
            hasHitBackWall= false;
        }
    }
}
