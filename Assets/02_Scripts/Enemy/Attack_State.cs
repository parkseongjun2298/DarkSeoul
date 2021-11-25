using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_State : FSM_State<Monster>
{
    private static readonly Attack_State instance = new Attack_State();

    public static Attack_State Instance
    {
        get { return instance; }
    }

    private float AttackTimer = 0f;
    
    static Attack_State() {}
    private Attack_State() {}

    public override void EnterState(Monster _Monster)
    {
        if (_Monster.myTarget == null)
        {
            return;
        }

        AttackTimer = _Monster.AttackSpeed;
    }

    public override void UpdateState(Monster _Monster)
    {
        if (_Monster.CurrentHP <= 0)
        {
            _Monster.ChangeState(Die_State.Instance);
        }

        AttackTimer += Time.deltaTime;
        if (! _Monster.CheckAngle() && _Monster.CheckRange())
        {
            if (AttackTimer >= _Monster.AttackSpeed)
            {
                int Damage = _Monster.MonsterDamage;
                AttackTimer = 0.0f;
                _Monster.ChaseTime = 0.0f;
            }
        }
        else
        {
            _Monster.ChangeState(Move_State.Instance);
        }
    }

    public override void ExitState(Monster _Monster)
    {
        Debug.Log("Attack_State 나옴");
    }
}
