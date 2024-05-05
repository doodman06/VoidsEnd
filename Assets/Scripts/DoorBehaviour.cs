using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private bool isLocked = true;
    [SerializeField] private Sprite unlockedSprite;
    [SerializeField] private GameObject popup;
    private SpriteRenderer spriteRenderer;
    private PlayerInput playerInput;
    private bool canEndLevel = false;
    private InputAction interactAction;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        LoadActions();
        interactAction = playerInput.actions.FindAction("Interact");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>() && !isLocked)
        {
            canEndLevel = true;
            popup.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>())
        {
            canEndLevel = false;
            popup.SetActive(false);
        }
    }

    private void LoadActions()
    {
        playerInput.actions.LoadBindingOverridesFromJson(PlayerPrefs.GetString("ControlBindings"));
    }

    public void endLevel()
    {
        //end the level and go to the start screen
        SceneManager.LoadScene("StartScene");
    }

    private void Update()
    {
        if (canEndLevel && interactAction.IsPressed())
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
