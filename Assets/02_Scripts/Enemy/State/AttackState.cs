using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private Enemy _enemy;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemy = animator.GetComponent<Enemy>();
        Debug.Log("공격중");
        _enemy.leftFist.gameObject.SetActive(true);
        _enemy.rightFist.gameObject.SetActive(true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemy.atkDelay = _enemy.atkCooltime;
        Debug.Log("공격끝");
        _enemy.leftFist.gameObject.SetActive(false);
        _enemy.rightFist.gameObject.SetActive(false);
    }
}
