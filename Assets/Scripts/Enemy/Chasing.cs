using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class Chasing : BaseState
    {
        private EnemySM _sm;
        private bool caughtPlayer;


        public Chasing(EnemySM stateMachine) : base("Chasing", stateMachine)
        {
            _sm = stateMachine;
        }

        public override void Enter()
        {
            _sm.anim.SetBool("isWalk", true);
        }

        public override void UpdateLogic()
        {
            if (!_sm.peacefull)
            {
                if (Vector3.Distance(_sm.thisEnemy.position, _sm.player.transform.position) >= 17f)
                {
                    stateMachine.ChangeState(_sm.idleState);
                }

                else if(Vector3.Distance(_sm.thisEnemy.position, _sm.player.transform.position) <= _sm.attackDistance)
                {
                    if (!_sm.ranged)
                    {
                        stateMachine.ChangeState(_sm.meleeAttack);
                    }

                    else
                    {
                        stateMachine.ChangeState(_sm.rangedAttack);
                    }
                }

                else
                {
                    _sm.navMeshAgent.SetDestination(_sm.player.transform.position);
                    _sm.navMeshAgent.isStopped = false;
                } 
            }

            //Peacefull Enemy
            else if(_sm.peacefull)
            {
                if (_sm.getDamage)
                {
                    if (Vector3.Distance(_sm.thisEnemy.position, _sm.player.transform.position) >= 17f)
                    {
                        stateMachine.ChangeState(_sm.idleState);
                    }
                    
                    else if(Vector3.Distance(_sm.thisEnemy.position, _sm.player.transform.position) <= _sm.attackDistance)
                    {
                        if (!_sm.ranged)
                        {
                            stateMachine.ChangeState(_sm.meleeAttack);
                        }

                        else
                        {
                            stateMachine.ChangeState(_sm.rangedAttack);
                        }
                    }
                    
                    else
                    {
                        _sm.navMeshAgent.SetDestination(_sm.player.transform.position);
                        _sm.navMeshAgent.isStopped = false;
                    }
                }
            }
        }

        public override void Exit()
        {
            _sm.anim.SetBool("isWalk", false);
        }
    }
}
