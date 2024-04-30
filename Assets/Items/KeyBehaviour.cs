using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] doors;
    [SerializeField] private AudioClip pickupClip;
    private Observer[] observers;
    private DoorBehaviour[] doorBehaviours;

    private void Awake()
    {
        observers = FindObjectsOfType<Observer>();
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
            Notify(EventEnum.Key);
            OnKill();
            Destroy(gameObject);
        }
    }

    private void OnKill()
    {
        AudioSource.PlayClipAtPoint(pickupClip, transform.position, SoundManagerBehaviour.getSfxVolume());
    }

    private void Notify(EventEnum currentEvent)
    {
        foreach (Observer observer in observers)
        {
            observer.OnNotify(currentEvent);
        }
    }
 
}
