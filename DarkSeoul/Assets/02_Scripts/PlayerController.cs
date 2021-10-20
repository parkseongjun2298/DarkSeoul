using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private CameraController cameraController;
    
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        KeyInput();
        MouseInput();
    }

    void KeyInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        playerMovement.MoveTo(new Vector3(x, 0, z));
    }

    void MouseInput()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        cameraController.RotateTo(mouseX, mouseY);
    }

}
