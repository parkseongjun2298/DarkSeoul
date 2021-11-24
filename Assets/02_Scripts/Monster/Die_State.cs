using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Die_State : FSM_State<Monster>
{
    private static readonly Die_State instance = new Die_State();

    public static Die_State Instance
    {
        get
        {
            return instance;
        }
    }

    private float Count = 2f;
    private float time = 0f;

    static Die_State() {}
    private Die_State() {}

    public override void EnterState(Monster _Monster)
    {
        _Monster.IsDead = true;
    }

    public override void UpdateState(Monster _Monster)
    {
        time += Time.deltaTime;

        if (_Monster.isActiveAndEnabled && time >= Count)
        {
            _Monster.gameObject.SetActive(false);
            time = 0f;
        }
    }

    public override void ExitState(Monster _Monster)
    {
        Debug.Log("Die State 나옴");
    }
}
