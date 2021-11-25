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
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy.enemyHealth > 0)
                enemy.enemyHealth -= playerController.playerDamage;
            
            if (enemy.enemyHealth <= 0 && !enemy.isDead)
            {
                enemy.animator.SetTrigger("doDead");
                enemy.isDead = true;
                enemy.EnemyDead();
            }
        }
    }
}
