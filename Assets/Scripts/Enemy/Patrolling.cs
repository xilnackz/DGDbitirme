using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG
{
    public class Patrolling : BaseState
    {
        //Companents
        private EnemySM _sm;
        public Patrolling(EnemySM stateMachine) : base("Patrolling", stateMachine) { _sm = stateMachine; }

        //Values
        private float viewRadius = 10;
        private float viewAngle = 90f;
        private int currentWayPointIndex = 0;
        private float patrollingSpeed = 6;

        public override void Enter()
        {
            _sm. anim.SetBool("isWalk", true);
        }

        public override void UpdateLogic()
        {
            DetectedPlayer();
            PatrollingEnemy();
        }

        private void PatrollingEnemy()
        {
            _sm.navMeshAgent.SetDestination(_sm.wayPoints[currentWayPointIndex].position);
            _sm.navMeshAgent.isStopped = false;
            _sm.navMeshAgent.speed = patrollingSpeed;

            if (_sm.navMeshAgent.remainingDistance <= _sm.navMeshAgent.stoppingDistance)
            {
                NextPoint();
                stateMachine.ChangeState(_sm.idleState);
            }
        }
        
        public void NextPoint()
        {
            currentWayPointIndex = (currentWayPointIndex + 1) % _sm.wayPoints.Length;
            _sm.navMeshAgent.SetDestination(_sm.wayPoints[currentWayPointIndex].position);
        }
        private void DetectedPlayer()
        {
            Collider[] playerInRange = Physics.OverlapSphere(_sm.thisEnemy.position, viewRadius, _sm.playerMask);
            
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

                    else if (_sm.peacefull && _sm.getDamage)
                    {
                        stateMachine.ChangeState(_sm.chasingState);
                    }
                }
            }
        }
    }
}
