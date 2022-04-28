using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask platformLayer;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && IsGrounded())
            Jump();
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, platformLayer);
        return raycastHit.collider != null;
    }
}
