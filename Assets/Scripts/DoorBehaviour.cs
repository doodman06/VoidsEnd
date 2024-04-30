using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private bool isLocked = true;
    [SerializeField] private Sprite unlockedSprite;
    private SpriteRenderer spriteRenderer;
    private bool canEndLevel = false;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>() && !isLocked)
        {
            canEndLevel = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>())
        {
            canEndLevel = false;
        }
    }

    public void endLevel()
    {
        //end the level and go to the start screen
        SceneManager.LoadScene("StartScene");
    }

    private void Update()
    {
        if (canEndLevel && Input.GetKeyDown(KeyCode.F))
        {
            endLevel();
        }
    }
    public void unlock()
    {
        isLocked = false;
        spriteRenderer.sprite = unlockedSprite;

    }
    
}
