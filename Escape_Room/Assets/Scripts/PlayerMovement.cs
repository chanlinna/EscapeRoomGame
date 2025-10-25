using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement Variables (Set in Inspector)
    [SerializeField]
    private float moveSpeed = 5.0f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical");

        // transform the world directions (right, forward) based on the player's rotation
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        
        // multiply by Time.deltaTime to make the movement frame-rate independent.
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}