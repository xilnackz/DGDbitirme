using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class StateMachine : MonoBehaviour
    {
        public BaseState currentState;
        public Idle idleState;

        private void Start()
        {
            currentState = GetInitialState();
            
            if (currentState != null)
            {
                currentState.Enter();
            }
        }

        private void Update()
        {
            if (currentState != null)
            {
                currentState.UpdateLogic();
            }
        }

        private void LateUpdate()
        {
            if (currentState != null)
            {
                currentState.UpdatePhysics();
            }
        }

        public void ChangeState(BaseState newState)
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }

        protected virtual BaseState GetInitialState()
        {
            return null;
        }
        /*
        private void OnGUI()
        {
            string content = currentState != null ? currentState.name : "{no current state}";
            GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        }*/
    }
}
