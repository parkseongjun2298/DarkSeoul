using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyState : StateMachineBehaviour
{
    private Transform _enemyTransform;
    private Enemy _enemy;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemy = animator.GetComponent<Enemy>();
        _enemyTransform = animator.GetComponent<Transform>();
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_enemy.atkDelay <= 0)
            animator.SetTrigger("doAttack");

        if (Vector3.Distance(_enemy._player.position, _enemyTransform.position) > 1f)
            animator.SetBool("isFollow", true);
        
        _enemy.RotateEnemy(_enemy._player.position);
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
