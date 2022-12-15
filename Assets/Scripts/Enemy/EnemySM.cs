using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace RPG
{
    public class EnemySM : StateMachine
    {
        public Idle idleState;
        public Chasing chasingState;
        public MeleeAttack meleeAttack;
        public Patrolling patrolling;
        public RangedAttack rangedAttack;

        //Companents
        public Transform player;
        public Transform thisEnemy;
        public NavMeshAgent navMeshAgent;
        public LayerMask playerMask;
        public LayerMask obstacleMask;
        public Transform[] wayPoints;
        public Animator anim;
        
        //Values
        public float attackDistance = 1f;
        public float enemyDetectedRadius = 15;
        public bool getDamage;
        
        //Peacefull
        public bool peacefull;
        
        //Ranged
        public bool ranged;
        //public Arrow arrow;
        public float arrowSpeed = 20f;
        public Transform refArrowSpawn;
        public bool bowAttackAnim = false;

        private void Awake()
        {
            idleState = new Idle(this);
            chasingState = new Chasing(this);
            meleeAttack = new MeleeAttack(this);
            patrolling = new Patrolling(this);
            rangedAttack = new RangedAttack(this);
        }
        protected override BaseState GetInitialState()
        {
            return idleState;
        }

        
        public void ExitAnimation()
        {
            meleeAttack.attackEnd = true;
        }

        
       /* public void BowSpawn()
        {
            Arrow thisArrow = ArrowPooling.instance.GetArrowFromPool();
            thisArrow.transform.position = refArrowSpawn.position;
            thisArrow.transform.rotation = thisEnemy.rotation;
            thisArrow.gameObject.SetActive(true);
            thisArrow.rb.AddForce((player.position - thisEnemy.position) * arrowSpeed, ForceMode.Force);
        }*/
    }
}
