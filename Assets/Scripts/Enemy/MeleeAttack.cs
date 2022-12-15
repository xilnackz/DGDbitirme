using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class MeleeAttack : BaseState
    {
        private EnemySM _sm;
        public MeleeAttack(EnemySM stateMachine) : base("MeleeAttack", stateMachine) { _sm = stateMachine; }
        public bool attackEnd;

        public override void Enter()
        {
            
            attackEnd = false;
            _sm.navMeshAgent.velocity = Vector3.zero;
            _sm.navMeshAgent.isStopped = true;
            _sm.anim.SetTrigger("attack");
            _sm.anim.SetBool("attackcombo", true);
        }

        public override void UpdateLogic()
        {
            Vector3 lookDirection = _sm.player.transform.position - _sm.thisEnemy.transform.position;
         
            lookDirection.Normalize();

            _sm.thisEnemy.transform.rotation = Quaternion.Slerp(_sm.thisEnemy.transform.rotation, Quaternion.LookRotation(lookDirection), 2 * Time.deltaTime);

            
            
            if (Vector3.Distance(_sm.thisEnemy.position, _sm.player.transform.position) > _sm.attackDistance)
            {
                _sm.anim.SetBool("attackcombo", false);
               
                if (attackEnd)
                {
                    stateMachine.ChangeState(_sm.chasingState); 
                }
            }
        }
    }
}
