using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class Idle : BaseState
    {
        //Companents
        private EnemySM _sm;
        public Idle(EnemySM stateMachine) : base("Idle", stateMachine) { _sm = stateMachine; }
        
        //Values
        private float viewAngle = 90f;
        private float startedTime = 4;
        private float timer;
        
        
        
        public override void Enter()
        {
            _sm.anim.SetBool("isWalk", false);
            timer = startedTime;
            _sm.navMeshAgent.isStopped = true;
            _sm.navMeshAgent.updatePosition = true;
        }

        public override void UpdateLogic()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                stateMachine.ChangeState(_sm.patrolling);
            }
            
            Collider[] playerInRange = Physics.OverlapSphere(_sm.thisEnemy.position, _sm.enemyDetectedRadius, _sm.playerMask);
            
            for (int i = 0; i < playerInRange.Length; i++)
            {
                Transform player = playerInRange[i].transform;
                
                Vector3 dirToPlayer = (player.position - _sm.thisEnemy.position).normalized;
               
                if (Vector3.Angle(_sm.thisEnemy.forward, dirToPlayer) < viewAngle / 2);
                {
                    float dstToPlayer = Vector3.Distance(_sm.thisEnemy.position, player.position);
                    
                    if (!Physics.Raycast(_sm.thisEnemy.position, dirToPlayer, dstToPlayer ,_sm.obstacleMask) && !_sm.peacefull)
                    {
                        stateMachine.ChangeState(_sm.chasingState);
                    }

                    else
                    {
                        stateMachine.ChangeState(_sm.patrolling);
                    }
                }
            }
        }
    }
}
