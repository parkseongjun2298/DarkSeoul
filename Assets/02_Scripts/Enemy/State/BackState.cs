using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackState : StateMachineBehaviour
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
        if(Vector3.Distance(_enemy.spawn, _enemyTransform.position) < 0.1f || Vector3.Distance(_enemyTransform.position, _enemy._player.position) < 3f)
            animator.SetBool("isBack", false);
        else
        {
            _enemyTransform.position =
                Vector3.MoveTowards(_enemyTransform.position, _enemy.spawn, Time.deltaTime * _enemy.speed);
        }
        
        _enemy.RotateEnemy(_enemy.spawn);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
