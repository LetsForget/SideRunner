using System;
using UnityEngine;

namespace Character.StateMachines.Base
{
    public abstract class StateMachine<Input> where Input : Enum
    {
        public State<Input> CurrentState { get; private set; }

        protected void GoToState(State<Input> state)
        {
            if (CurrentState != null)
            {
                ExitFromState();
                CurrentState = null;
            }
            
            CurrentState = state;
            EnterNewState();
        }

        protected virtual void ExitFromState()
        {
            CurrentState.OnExit();
        }

        protected virtual void EnterNewState()
        {
            CurrentState.OnEnter();
        }
        
        public void OnInput(Input input)
        {
            CurrentState?.OnInput(input);
        }
        
        public void Update()
        {
            CurrentState?.Update();
        }
    }
}