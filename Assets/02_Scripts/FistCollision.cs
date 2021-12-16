using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistCollision : MonoBehaviour
{
    private Enemy enemy;
    public AudioSource audioSource;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            //Debug.Log("맞음");

            audioSource.Play();
            
            player.playerHealth -= enemy.enemyDamage;
        }
    }
}
