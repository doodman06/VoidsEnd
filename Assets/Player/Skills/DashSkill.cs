using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DashSkill : Skill
{
    [SerializeField] private float dashVelocity;
    [SerializeField] private float dashTime;

    private float timeDashing;
    private bool direction;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private MovementBehaviour mb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        mb = GetComponent<MovementBehaviour>();
    }

    public void UseDash()
    {
        UseSkill();
        Debug.Log("Dash skill used");
        
    }

    public override void StartSkill()
    {
        Debug.Log("Dash skill started");
        direction = spriteRenderer.flipX;
        if (direction)
        {
            rb.velocity = rb.velocity + new Vector2(-GetDashVelocity(), 0);
        }
        else
        {
            rb.velocity = rb.velocity + new Vector2(GetDashVelocity(), 0);
        }
        timeDashing = 0f;
    }

    public override void EndSkill()
    {
        Debug.Log("Dash skill ended");
        UseDash();
        mb.Stop();

    }

    public override bool UpdateSkill(PlayerInputEnum input)
    {
        Debug.Log("Dash skill updated");
        timeDashing += Time.deltaTime;
        if (timeDashing >= GetDashTime())
        {
            return true;
        } 
        else
        {
            return false;
        }
                
    }

    public float GetDashVelocity()
    {
        return dashVelocity;
    }

    public float GetDashTime()
    {
        return dashTime;
    }
}
