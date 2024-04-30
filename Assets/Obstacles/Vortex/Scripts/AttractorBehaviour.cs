using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class AttractorBehaviour : MonoBehaviour
{
    private CircleCollider2D myCollider;

    [SerializeField] private float attractionForce;
    [SerializeField] private float attractionRadius;
    [SerializeField] private float maxForce;

    private Vector2 myPosition;

    private AttractionBehaviour ab;

    private void Awake()
    {
        myCollider = GetComponent<CircleCollider2D>();
        myCollider.radius = attractionRadius;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        myPosition = transform.position;
        ab = collision.gameObject.GetComponent<AttractionBehaviour>();

        if (ab  != null)
        {
            ab.Attract(myPosition, attractionForce, maxForce);
        }
    }


}
