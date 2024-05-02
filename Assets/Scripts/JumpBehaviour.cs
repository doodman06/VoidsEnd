using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class JumpBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float fallingGravity = 2.5f;
    [SerializeField] private float initialJumpDistance = 0.05f; 

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Jump()
    {
        transform.Translate(Vector2.up * initialJumpDistance);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        playJumpSound();
    }

    private void playJumpSound()
    {
        jumpSound.volume = SoundManagerBehaviour.getSfxVolume();
        jumpSound.Play();
    }


    public bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, initialJumpDistance, jumpableGround);
    }

    public bool IsFalling()
    {
        return rb.velocity.y < 0;
    }

    public void ApplyFallingGravity()
    {
        rb.gravityScale = fallingGravity;
    }

    public void ResetGravity()
    {
        rb.gravityScale = 1;
    }
   
}
