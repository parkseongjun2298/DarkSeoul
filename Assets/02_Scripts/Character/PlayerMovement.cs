using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    private float gravity = -9.81f;
    private Vector3 moveDirection;

    [SerializeField] private Transform cameraTransform;
    private CharacterController characterController;
    
    private float rotateSpeedX = 3;
    
    private float eulerAngleY;
    
    private float limitMinX = -80;
    private float limitMaxX = 50;
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!characterController.isGrounded)
            moveDirection.y += gravity * Time.deltaTime;
        
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        Vector3 rotDirection = cameraTransform.rotation * direction;
        
        moveDirection = new Vector3(rotDirection.x, moveDirection.y, rotDirection.z);
    }
    
    public void RotateTo(float mouseX)
    {
        eulerAngleY += mouseX * rotateSpeedX;

        transform.rotation = Quaternion.Euler(0, eulerAngleY, 0);
    }

    public void ChangeMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
