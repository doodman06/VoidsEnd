using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractorBehaviour : MonoBehaviour
{
    private AttractionBehaviour[] ab;

    [SerializeField] private float attractionForce;
    [SerializeField] private float attractionRadius;
    [SerializeField] private float maxForce;

    private Vector2 attractorPosition;
    private Vector2 myPosition;
    private float distance;

    private void Awake()
    {
        ab = FindObjectsOfType<AttractionBehaviour>();
    }

    private void FixedUpdate()
    {
        for(int i = 0; i < ab.Length; i++)
        {
            attractorPosition = ab[i].transform.position;
            myPosition = transform.position;
            distance = Vector2.Distance(attractorPosition, myPosition);

            if (distance < attractionRadius)
            {
                ab[i].Attract(myPosition, attractionForce, maxForce);
            }
        }
    }
}
