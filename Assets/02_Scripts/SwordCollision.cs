using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    public PlayerController playerController;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("칼 몬스터 충돌");
            other.GetComponent<Enemy>().enemyHealth -= playerController.playerDamage;
        }
    }
}
