using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class AttractionBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private float distance;
    private Vector2 direction;
    private float currentForce;
 

    

    private void Awake()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    public void Attract(Vector2 targetPosition, float force, float maxForce)
    {
        direction = targetPosition - (Vector2)transform.position;
        distance = direction.magnitude;
        currentForce = force / (distance * distance);
        if(currentForce > maxForce)
        {
            currentForce = maxForce;
        }
      

        rb.AddForce(direction.normalized * currentForce );
    }


}
