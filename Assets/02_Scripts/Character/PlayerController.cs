using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    
    [SerializeField] private Transform characterBody;
    [SerializeField] private Transform cameraArm;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController characterController;
    
    void Update()
    {
        KeyInput();
        MouseInput();
        Attack();
        
    }

    void KeyInput()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (moveInput.magnitude != 0)
        {
            animator.SetBool("isWalk", true);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                animator.SetBool("isRun", true);
                moveSpeed = 5.0f;
            }
        }
        else
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
            moveSpeed = 3.0f;
        }

        Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
        Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
        Vector3 moveDirection = lookForward * moveInput.y + lookRight * moveInput.x;

        characterBody.forward = lookForward;
        
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

    }

    void MouseInput()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;

        float a = camAngle.x - mouseDelta.y;

        if (a < 180f)
        {
            a = Mathf.Clamp(a, -1f, 70f);
        }
        else
        {
            a = Mathf.Clamp(a, 335f, 361f);

        }
        
        cameraArm.rotation = Quaternion.Euler(camAngle.x - mouseDelta.y, camAngle.y + mouseDelta.x, camAngle.z);
    }

    void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("doAttack");
        }
    }

}
