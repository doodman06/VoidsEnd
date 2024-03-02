using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractorBehaviour : MonoBehaviour
{
    private AttractionBehaviour[] ab;

    [SerializeField] private float attractionForce = 10f;
    [SerializeField] private float attractionRadius = 10f;

    private Vector2 attractorPosition;
    private Vector2 myPosition;
    private float distance;

    private void Awake()
    {
        ab = FindObjectsOfType<AttractionBehaviour>();
    }

    private void FixedUpdate()
    {
        foreach (AttractionBehaviour a in ab)
        {
            attractorPosition = a.transform.position;
            myPosition = transform.position;
            distance = Vector2.Distance(attractorPosition, myPosition);

            if (distance < attractionRadius)
            {
                a.Attract(myPosition, attractionForce);
            }
        }
    }
}
