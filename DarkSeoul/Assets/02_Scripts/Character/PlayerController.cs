using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Animator animator;
    
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        KeyInput();
        MouseInput();
        
        if (Input.GetMouseButton(0))
        {
            StartCoroutine("Attack");
        }
        
    }

    void KeyInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (x * x + z * z != 0)
        {
            animator.SetBool("isWalk", true);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                animator.SetBool("isRun", true);
                playerMovement.ChangeMoveSpeed(5.0f);
            }
        }
        else
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
            playerMovement.ChangeMoveSpeed(3.0f);
        }

        playerMovement.MoveTo(new Vector3(x, 0, z));
    }

    void MouseInput()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        cameraController.RotateTo(mouseX, mouseY);
        playerMovement.RotateTo(mouseX);
    }

    IEnumerator Attack()
    {
        animator.SetBool("isAttack", true);

        yield return new WaitForSeconds(1f);
        
        animator.SetBool("isAttack", false);
        
        yield return null;
    }

}
