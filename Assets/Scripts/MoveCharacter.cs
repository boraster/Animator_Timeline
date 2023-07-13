using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCharacter : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private Transform cameraTransform;
    private Animator animator;
    private CharacterController characterController;
    private int speedHash;
    private int isMovingHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        speedHash = Animator.StringToHash("Speed");
        isMovingHash = Animator.StringToHash("IsMoving");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        

        animator.SetFloat(speedHash, inputMagnitude, 0.05f, Time.deltaTime);

        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool(isMovingHash, true);

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool(isMovingHash, false);
        }
    }

    private void OnAnimatorMove()
    {
        Vector3 velocity = animator.deltaPosition;
        velocity.y = 0f;
        characterController.Move(velocity);
        // transform.Translate(velocity);
    }

    
}
