using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private bool isLocked = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>() && !isLocked)
        {
            endLevel();
            
        }
    }

    private void endLevel()
    {
        //end the level
        Debug.Log("Level ended");
    }
    public void unlock()
    {
        isLocked = false;
    }
    
}
