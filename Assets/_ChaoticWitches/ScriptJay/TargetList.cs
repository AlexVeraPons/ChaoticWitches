using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetList : MonoBehaviour
{
    [SerializeField] private LayerMask Tiles;
    public List<GameObject> targets = new List<GameObject>();
    private bool hasHitTile = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hitInfo, 5, Tiles))
        {
            if (hasHitTile == false)
            {
                targets.Add(hitInfo.collider.gameObject);
                hasHitTile = true;
            }
        } else hasHitTile = false;
    }
}
