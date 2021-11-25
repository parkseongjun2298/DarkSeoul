using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float enemyHealth = 100.0f;
    [SerializeField] public float enemyDamage = 5.0f;

    public bool isDead = false;
    
    public Animator animator;
    public Transform _player;
    public float speed;
    public Vector3 spawn;

    public float atkCooltime = 4;
    public float atkDelay;

    public BoxCollider leftFist;
    public BoxCollider rightFist;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        spawn = transform.position;
    }

    private void Update()
    {
        if (atkDelay >= 0)
            atkDelay -= Time.deltaTime;
        
    }

    public void RotateEnemy(Vector3 _target)
    {
        transform.forward = _target - transform.position;
    }

    public void EnemyDead()
    {
        Invoke("DeleteEnemy", 3.0f);
    }

    private void DeleteEnemy()
    {
        Destroy(this.gameObject);
    }
}
