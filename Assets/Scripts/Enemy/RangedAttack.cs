using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

namespace RPG
{
    public class RangedAttack : BaseState
    {
        private EnemySM _sm;
        public RangedAttack(EnemySM stateMachine) : base("RangedAttack", stateMachine) { _sm = stateMachine; }
        private float timer = 0;
        private Vector3 lookDirection;
        public bool attackEnd;
        

        public override void Enter()
        {
            attackEnd = false;
            _sm.navMeshAgent.velocity = Vector3.zero;
            _sm.navMeshAgent.isStopped = true;
            _sm.anim.SetTrigger("bowAttackTrigger");
            _sm.anim.SetBool("bowAttack", true);
        }

        public override void UpdateLogic()
        { 
            lookDirection = _sm.player.transform.position - _sm.thisEnemy.transform.position;
            
            lookDirection.Normalize();
            
            _sm.thisEnemy.transform.rotation = Quaternion.Slerp(_sm.thisEnemy.transform.rotation, Quaternion.LookRotation(lookDirection), 4 * Time.deltaTime);

            if (Vector3.Distance(_sm.thisEnemy.position, _sm.player.transform.position) > _sm.attackDistance)
            {
                _sm.anim.SetBool("bowAttack", false);

                if (attackEnd)
                {
                    stateMachine.ChangeState(_sm.chasingState); 
                }
            }

            else
            {
                
            }
        }
    }
}
