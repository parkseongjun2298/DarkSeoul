using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float playerHealth = 100.0f;
    [SerializeField] public int playerMoney = 0;
    [SerializeField] public int potionCount = 0;

    [SerializeField] public AudioClip attackSound;

    public AudioSource audioSource;
    
    [SerializeField] public float playerDamage = 10.0f;
    
    [SerializeField] private float moveSpeed = 5.0f;

    [SerializeField] private float SkillCooltime = 2.0f;
    [SerializeField] private float CurCooltime = 0.0f;
    [SerializeField] private bool isSkiilOn = true;

    [SerializeField] private Vector3 playerRay;

    [SerializeField] private GameObject knife;
    private GameObject go;
    
    [SerializeField] private Transform characterBody;
    [SerializeField] private Transform cameraArm;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController characterController;

    [SerializeField] public BoxCollider swordCollider;
    
    void Update()
    {
        KeyInput();
        MouseInput();
        Attack();
        ItemKey();
        Skill();
        KnifeUpdate();

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
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("doAttack");
            swordCollider.gameObject.SetActive(true);
            Invoke("SwordColliderOff", 1.0f);
            audioSource.PlayOneShot(attackSound);
        }
    }

    void Skill()
    {
        if (Input.GetMouseButtonDown(1) && isSkiilOn)
        {
            animator.SetTrigger("doAttack");
            go = Instantiate(knife, new Vector3(transform.position.x, transform.position.y + 1.4f, transform.position.z), Quaternion.identity);
            
            isSkiilOn = false;
            
            playerRay = characterBody.transform.forward;
            CurCooltime = 0.0f;

            
            

        }
    }

    void KnifeUpdate()
    {
        if (!isSkiilOn)
        {
            go.transform.Translate(playerRay.normalized * Time.deltaTime * 20.0f);

            CurCooltime += Time.deltaTime;

            if (SkillCooltime <= CurCooltime)
            {
                isSkiilOn = true;
                Destroy(go);
            }
        }
    }

    void SwordColliderOff()
    {
        swordCollider.gameObject.SetActive(false);
    }

    void ItemKey()
    {
        if (Input.GetKeyDown(KeyCode.E) && potionCount > 0)
        {
            potionCount -= 1;
            playerHealth = 100.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Potion")
        {
            Destroy(other.gameObject);
            potionCount += 1;
        }
        
    }
}
