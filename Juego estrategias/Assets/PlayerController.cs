using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 7;
    [SerializeField]
    private Transform movePoint;
    [SerializeField]
    private LayerMask obstacleMask;

    void Start()
    {
        movePoint.parent = null; // Detach partent
    }

    void Update()
    {
        float movementAmout = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementAmout);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                Move(new Vector3(-1, 0, 0));
            }
            if (Input.GetAxisRaw("Vertical") < 0f)
            {
                Move(new Vector3(0, -1, 0));
            }
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                Move(new Vector3(1, 0, 0));
            }
            if (Input.GetAxisRaw("Vertical") > 0f)
            {
                Move(new Vector3(0, 1, 0));
            }
        }
    }

    private void Move(Vector3 direction)
    {
        Vector3 newPosition = movePoint.position + direction;
        if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleMask))
        {
            movePoint.position = newPosition;
        }
    }
}