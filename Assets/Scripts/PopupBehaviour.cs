using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PopupBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshPro popup;
    [SerializeField] private InputActionAsset inputActionAsset;
    private InputAction interactAction;
    // Start is called before the first frame update
    void Start()
    {
        interactAction = inputActionAsset.FindAction("Interact");
        popup.text = interactAction.GetBindingDisplayString(0);
        
    }

}
