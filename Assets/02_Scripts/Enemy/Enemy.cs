using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float enemyHealth = 100.0f;
    
    
    private Animator animator;
    public Transform _player;
    public float speed;
    public Vector3 spawn;

    public float atkCooltime = 4;
    public float atkDelay; 
    
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
    
}
