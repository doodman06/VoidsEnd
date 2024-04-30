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

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Jump()
    {
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
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
   
}
