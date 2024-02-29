using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class GroundBehaviour : MonoBehaviour
{


    private Collider2D col;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void applyNormalForce(IEntity e)
    {
        if (e.rigidbody.velocity.y <= 0)
        {
            e.rigidbody.velocity = new Vector2(e.rigidbody.velocity.x, 0);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            applyNormalForce(other.gameObject.GetComponent<IEntity>());
        }
    }   
}
