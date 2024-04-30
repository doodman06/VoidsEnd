using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] doors;
    [SerializeField] private AudioClip pickupClip;
    private DoorBehaviour[] doorBehaviours;

    private void Awake()
    {
        doorBehaviours = new DoorBehaviour[doors.Length];
        for (int i = 0; i < doors.Length; i++)
        {
            doorBehaviours[i] = doors[i].GetComponent<DoorBehaviour>();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>())
        {
            for (int i = 0; i < doorBehaviours.Length; i++)
            {
                doorBehaviours[i].unlock();
            }
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(pickupClip, transform.position, SoundManagerBehaviour.getSfxVolume());
    }
 
}
