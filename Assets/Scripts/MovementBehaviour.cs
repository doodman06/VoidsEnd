using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Move(float direction)
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

    }

    public void MoveRight()
    {
        Move(1);
    }

    public void MoveLeft()
    {
        Move(-1);
    }

    public void Stop()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}
