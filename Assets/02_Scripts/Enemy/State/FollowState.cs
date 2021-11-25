using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : StateMachineBehaviour
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
        if (Vector3.Distance(_enemy._player.position, _enemyTransform.position) > 5f)
        {
            animator.SetBool("isBack",true);
            animator.SetBool("isFollow", false);
        } else if (Vector3.Distance(_enemy._player.position, _enemyTransform.position) > 1f)
            _enemyTransform.position = Vector3.MoveTowards(_enemyTransform.position, _enemy._player.position,
                Time.deltaTime * _enemy.speed);
        else
        {
            animator.SetBool("isBack", false);
            animator.SetBool("isFollow", false);
        }
        
        _enemy.RotateEnemy(_enemy._player.position);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
