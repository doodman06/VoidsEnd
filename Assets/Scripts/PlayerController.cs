using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementBehaviour))]
[RequireComponent(typeof(JumpBehaviour))]
public class PlayerController : MonoBehaviour
{
    private MovementBehaviour movementBehaviour;
    private JumpBehaviour jumpBehaviour;
    private void Awake()
    {
        movementBehaviour = GetComponent<MovementBehaviour>();
        jumpBehaviour = GetComponent<JumpBehaviour>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            movementBehaviour.Move(1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementBehaviour.Move(-1);
        }
        else
        {
            movementBehaviour.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBehaviour.Jump();
        }
    }   
}
