using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class Move_State : FSM_State<Monster>
{
    private static readonly Move_State instance = new Move_State();

    public static Move_State Instance
    {
        get
        {
            return instance;
        }
    }

    private float ResetTime = 3f;
    private float CurrentTime;
    
    static Move_State() {}
    private Move_State() {}

    public override void EnterState(Monster _Monster)
    {
        CurrentTime = ResetTime;
    }

    public override void UpdateState(Monster _Monster)
    {
        if (_Monster.CurrentHP <= 0)
        {
            _Monster.ChangeState(Die_State.Instance);
        }

        if (_Monster.myTarget != null)
        {
            if (_Monster.CheckRange())
            {
                _Monster.ChaseTime += Time.deltaTime;
                if (_Monster.ChaseTime >= _Monster.ChaseCancleTime)
                {
                    _Monster.myTarget = null;
                    _Monster.ChaseTime = 0.0f;
                    return;
                }

                Vector3 Dir = _Monster.myTarget.position = _Monster.transform.position;
                Vector3 NorDir = Dir.normalized;
                
                Quaternion angle = Quaternion.LookRotation(NorDir);

                _Monster.transform.rotation = angle;

                Vector3 Pos = _Monster.transform.position;
                Pos += _Monster.transform.forward * Time.smoothDeltaTime * _Monster.MoveSpeed;
                _Monster.transform.position = Pos;
            }
            else
            {
                _Monster.ChangeState(Attack_State.Instance);
            }
        }
        else
        {
            SetRandDir(_Monster);

            Vector3 endPoint = _Monster.transform.position + (_Monster.transform.forward * 2f);
            endPoint.y += 1f;
            Debug.DrawLine(_Monster.transform.position, endPoint, Color.red);

            endPoint.y = 0;
            Vector3 pos = _Monster.transform.position;
            pos += _Monster.transform.forward * Time.smoothDeltaTime * (_Monster.MoveSpeed / 3f);
            _Monster.transform.position = pos;
        }
    }

    public override void ExitState(Monster _Monster)
    {
        Debug.Log("Move State 나옴");
    }

    void SetRandDir(Monster _Monster)
    {
        CurrentTime += Time.smoothDeltaTime;
        if (CurrentTime >= ResetTime)
        {
            _Monster.transform.forward = Quaternion.AngleAxis(Random.Range(0, 360f), Vector3.up) * Vector3.forward;
            ResetTime = Random.Range(1f, 4f);
            CurrentTime = 0f;
        }
    }
}
