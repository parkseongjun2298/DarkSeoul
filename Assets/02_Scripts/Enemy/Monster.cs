using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float MonsterHP = 50;
    public float CurrentHP = 50;
    public int MonsterDamage = 5;
    public float AttackRange = 2f;
    public float AttackSpeed = 1.5f;
    public float ChaseCancleTime = 5.0f;
    public float ChaseTime = 0;
    public float MoveSpeed = 2.5f;
    public float RotSpeed = 100;
    public Transform myTarget;
    private StateMachine<Monster> state = null;
    public Animator Ani = null;
    public float DeadTimmer = 0;

    public bool IsDead = false;
    //public      GameMGR                 MGR;
    //public      GameObject              HPBar;
    //public      HUDText                 DMGText                 = null;

    void Awake()
    {
        ResetState();

        Ani = GetComponent<Animator>();
        
        
    }

    void Update()
    {
        state.Update();
    }

    public void ChangeState(FSM_State<Monster> _State)
    {
        state.ChangeState(_State);
    }

    void OnTriggerEnter(Collider _Other)
    {
        if (_Other.transform.tag == "Player")
        {
            Debug.Log("플레이어가 접근함");

            myTarget = _Other.transform.Find("character name");

            if (CheckRange())
            {
                ChangeState(Attack_State.Instance);
            }
            else
            {
                ChangeState(Move_State.Instance);
            }
        }
        else
        {
            return;
        }
    }

    public bool CheckRange()
    {
        if (Vector3.Distance(myTarget.transform.position, transform.position) <= AttackRange)
        {
            return true;
        }

        return false;
    }

    public bool CheckAngle()
    {
        if (Vector3.Dot(myTarget.transform.position, transform.position) >= 0.5f)
        {
            return true;
        }

        return false;
    }

    public void ResetState()
    {
        CurrentHP = MonsterHP;
        state = new StateMachine<Monster>();
        
        state.Initial_Setting(this, Move_State.Instance);

        myTarget = null;
    }

}
